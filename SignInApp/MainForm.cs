using SignInApp.WindowInteraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApp
{
    public partial class MainWindow : Form
    {

        private ListViewColumnSorter signedInSorter = new ListViewColumnSorter(ListViewColumnSorter.SortMode.StringMode);
        private ListViewColumnSorter allMembersSorter = new ListViewColumnSorter(ListViewColumnSorter.SortMode.StringMode);

        public MainWindow()
        {
            //init components
            InitializeComponent();

            //other init
            signedInList.ListViewItemSorter = signedInSorter;
            allMembersList.ListViewItemSorter = allMembersSorter;

            //TODO : initialize data here
            using (MemoryStream teamInfoStream = DriveInteraction.Interactions.DownloadFile(DriveInteraction.DriveConstants.TEAMINFO_DRIVE_NAME))
            {

                MainProgram.AppState.OurTeam = new Team();

                if (teamInfoStream == null) //file was not present to download
                {
                    DriveInteraction.Interactions.UploadFile(DriveInteraction.DriveConstants.TEAMINFO_DRIVE_NAME, MainProgram.AppState.OurTeam.Serialize());
                }
                else //file was present and has been downloaded
                {
                    MainProgram.AppState.OurTeam.Deserialize(Encryption.Encryptors.DecryptWithStoredIV(teamInfoStream.ToArray(), MainProgram.AppState.SystemAes.Key, Encryption.EncryptionConstants.IV_LENGTH));
                }

            }

            MainProgram.AppState.CurrentlyIn = new SignInEventList();

            using (MemoryStream signedOutStream = DriveInteraction.Interactions.DownloadFile(DriveInteraction.DriveConstants.EVENT_DRIVE_NAME))
            {

                MainProgram.AppState.SignedOut = new SignInEventList();

                if (signedOutStream == null) //file was not present to download
                {
                    DriveInteraction.Interactions.UploadFile(DriveInteraction.DriveConstants.EVENT_DRIVE_NAME, MainProgram.AppState.SignedOut.Serialize());
                }
                else //file was present and has been downloaded
                {
                    MainProgram.AppState.SignedOut.Deserialize(Encryption.Encryptors.DecryptWithStoredIV(signedOutStream.ToArray(), MainProgram.AppState.SystemAes.Key, Encryption.EncryptionConstants.IV_LENGTH));
                }

            }

            //SetUp Lists
            /*foreach (SignInEvent inEvent in MainProgram.AppState.CurrentlyIn.EventList)
            {
                signedInList.Items.Add(new InEventListItem(inEvent));
            }*/
            // ^^ should be blank on init

            updateMembersList();

            //Focus textBox
            this.ActiveControl = numberBox;
        }

        private void updateMembersList()
        {
            allMembersList.Items.Clear();
            foreach (Member member in MainProgram.AppState.OurTeam.Members)
            {
                allMembersList.Items.Add(new TeamMemberListItem(member));
            }
        }

        private void updateSignedInList()
        {
            signedInList.Items.Clear();
            foreach (SignInEvent inEvent in MainProgram.AppState.CurrentlyIn.EventList)
            {
                signedInList.Items.Add(new InEventListItem(inEvent));
            }
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            int number;
            
            if (Int32.TryParse(numberBox.Text, out number))
            {
                Member member = DriveInteraction.Interactions.LookupMember(number);
                if (member != null)
                {
                    if (MainProgram.AppState.CurrentlyIn.TrackAndUnloadNumber(number, ref MainProgram.AppState.SignedOut)) //unloaded
                    {
                        signInLabel.Text = "Goodbye " + member.FirstName + "!";
                        DriveInteraction.Interactions.UpdateFile(DriveInteraction.DriveConstants.EVENT_DRIVE_NAME, MainProgram.AppState.SignedOut.Serialize());
                    } else //not unloaded
                    {
                        signInLabel.Text = "Welcome " + member.FirstName + "!";
                    }

                    updateSignedInList();
                    updateMembersList();
                } else
                {
                    signInLabel.Text = "Member Not Recognized";
                }
            } else
            {
                signInLabel.Text = "Please Enter A Valid Number";
            }

            numberBox.Text = "";
        }

        private void registerUser_Click(object sender, EventArgs e)
        {
            using (RegisterUserForm registerUserForm = new RegisterUserForm())
            {
                registerUserForm.ShowDialog();
            }
            updateMembersList();
        }

        private void memberList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = allMembersList.SelectedItems.Count > 0 ? allMembersList.SelectedItems[0] : null;
            if (item != null)
            {
                int number;
                if (Int32.TryParse(item.Text, out number))
                {
                    using (InfoForm infoForm = new InfoForm(DriveInteraction.Interactions.LookupMember(number)))
                    {
                        infoForm.ShowDialog();
                    }
                }
            }
        }

        private void csvExport_Click(object sender, EventArgs e)
        {
            string exportFile = Interactions.GetSaveLocation("Save Hours CSV", "Comma Separated Value|*.csv");
            if (exportFile != "")
            {
                string exportContent = "Name, Number, Sign In Time, Sign Out Time, Elapsed Hours,\n";

                foreach (SignInEvent inEvent in MainProgram.AppState.SignedOut.EventList)
                {
                    Member member = DriveInteraction.Interactions.LookupMember(inEvent.Number);
                    if (member != null)
                    {
                        exportContent += member.FirstName + " " + member.LastName + ", "
                            + member.Number + ", "
                            + inEvent.SignInYear + " - " + inEvent.SignInMonth + " - " + inEvent.SignInDate + " " + inEvent.SignInHour + ":" + inEvent.SignInMinute + ", "
                            + inEvent.SignOutYear + " - " + inEvent.SignOutMonth + " - " + inEvent.SignOutDate + " " + inEvent.SignOutHour + ":" + inEvent.SignOutMinute + ", "
                            + inEvent.TimeElapsed.TotalHours + ",\n";
                    }
                 }

                Interactions.ExportData(exportFile, Encoding.ASCII.GetBytes(exportContent));
            }
        }

        private void jsonExport_Click(object sender, EventArgs e)
        {
            string exportFile = Interactions.GetSaveLocation("Save Hours JSON", "JSON File|*.json");
            if (exportFile != "")
            {
                string exportContent = MainProgram.AppState.SignedOut.Serialize();
                Interactions.ExportData(exportFile, Encoding.ASCII.GetBytes(exportContent));
            }
        }

        private void exportTeamCSV_Click(object sender, EventArgs e)
        {
            string exportFile = Interactions.GetSaveLocation("Save Team CSV", "Comma Separated Value|*.csv");
            if (exportFile != "")
            {
                string exportContent = "Name, Number, Total Hours,\n";

                foreach (Member member in MainProgram.AppState.OurTeam.Members)
                {
                    exportContent += member.FirstName + " " + member.LastName + ", "
                        + member.Number + ", "
                        + MainProgram.AppState.SignedOut.GetEventsByNumber(member.Number).SumTime().TotalHours + ",\n";

                }

                Interactions.ExportData(exportFile, Encoding.ASCII.GetBytes(exportContent));
            }
        }

        private void exportTeamJSON_Click(object sender, EventArgs e)
        {
            string exportFile = Interactions.GetSaveLocation("Save Team JSON", "JSON File|*.json");
            if (exportFile != "")
            {
                string exportContent = MainProgram.AppState.OurTeam.Serialize();
                Interactions.ExportData(exportFile, Encoding.ASCII.GetBytes(exportContent));
            }
        }

        private void deleteUserMenuItem_Click(object sender, EventArgs e)
        {
            using (DeleteMemberForm deleteMemberForm = new DeleteMemberForm())
            {
                deleteMemberForm.ShowDialog();
                updateMembersList();
                updateSignedInList();
            }
        }

        private void changePasswordMenuItem_Click(object sender, EventArgs e)
        {
            using (UpdatePasswordForm updatePasswordForm = new UpdatePasswordForm())
            {
                updatePasswordForm.ShowDialog();
            }
        }

        private void startScanningButton_Click(object sender, EventArgs e)
        {
            numberBox.Focus();
        }

        private void allMembersList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader header = allMembersList.Columns[e.Column];

            if (header.Text == "Number" || header.Text == "Hours")
                allMembersSorter.SortingMode = ListViewColumnSorter.SortMode.NumericMode;
            else
                allMembersSorter.SortingMode = ListViewColumnSorter.SortMode.StringMode;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == allMembersSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (allMembersSorter.Order == SortOrder.Ascending)
                {
                    allMembersSorter.Order = SortOrder.Descending;
                }
                else
                {
                    allMembersSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                allMembersSorter.SortColumn = e.Column;
                allMembersSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            allMembersList.Sort();
        }

        private void signedInList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader header = signedInList.Columns[e.Column];

            if (header.Text == "Number" || header.Text == "Hours")
                signedInSorter.SortingMode = ListViewColumnSorter.SortMode.NumericMode;
            else
                signedInSorter.SortingMode = ListViewColumnSorter.SortMode.StringMode;


            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == signedInSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (signedInSorter.Order == SortOrder.Ascending)
                {
                    signedInSorter.Order = SortOrder.Descending;
                }
                else
                {
                    signedInSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                signedInSorter.SortColumn = e.Column;
                signedInSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            signedInList.Sort();
        }
    }
}
