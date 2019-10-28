using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApp.WindowInteraction
{
    class Interactions
    {
        public static bool AuthenticatePasswordWindow()
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.ShowDialog();
            return passwordForm.PasswordEntered;
        }

        /**
         *  @return true if app is to close 
         */
        public static bool RecoverInternetAccess()
        {
            using (RecoverConnectionForm recoverConnectionForm = new RecoverConnectionForm())
            {
                recoverConnectionForm.ShowDialog();
                return recoverConnectionForm.CloseApp;
            }
        }

        public static string GetSaveLocation(string title, string extensionInfo)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = title;
                saveDialog.Filter = extensionInfo;
                saveDialog.ShowDialog();
                return saveDialog.FileName;
            }
        }

        public static void ExportData(string fileName, byte[] content)
        {
            using (FileStream exportFile = File.Create(fileName))
            {
                try
                {
                    exportFile.Write(content, 0, content.Length);
                }
                catch (IOException e)
                {
                   
                }
            }
        }

    }

    class TeamMemberListItem : ListViewItem
    {
        public int Number;
        public string FirstName;
        public string LastName;
        public double Hours;

        public TeamMemberListItem(Member member)
        {
            Number = member.Number;
            FirstName = member.FirstName;
            LastName = member.LastName;
            Hours = MainProgram.AppState.SignedOut.GetEventsByNumber(Number).SumTime().TotalHours;

            this.Text = "" + Number;
            this.SubItems.Add(new ListViewSubItem(this, FirstName));
            this.SubItems.Add(new ListViewSubItem(this, LastName));
            this.SubItems.Add(new ListViewSubItem(this, "" + Hours));
        }
    }

    class InEventListItem : ListViewItem
    {
        public int Number;
        public string FirstName;
        public string LastName;
        public DateTime TimeIn;

        public InEventListItem(SignInEvent inEvent)
        {
            Number = inEvent.Number;
            Member member = DriveInteraction.Interactions.LookupMember(Number);
            FirstName = (member != null ? member.FirstName : "<Invalid>");
            LastName = (member != null ? member.LastName : "<Invalid>");
            TimeIn = new DateTime(inEvent.SignInYear, inEvent.SignInMonth, inEvent.SignInDate, inEvent.SignInHour, inEvent.SignInMinute, inEvent.SignInSecond); ;

            this.Text = "" + Number;
            this.SubItems.Add(new ListViewSubItem(this, FirstName));
            this.SubItems.Add(new ListViewSubItem(this, LastName));
            this.SubItems.Add(new ListViewSubItem(this, "" + TimeIn.Hour + ":" + TimeIn.Minute));
        }
    }

    class SignInListItem : ListViewItem
    {
        public SignInEvent InEvent;

        public SignInListItem(SignInEvent inEvent)
        {
            InEvent = inEvent;

            this.Text = InEvent.SignInYear + " - " + InEvent.SignInMonth + " - " + InEvent.SignInDate;
            this.SubItems.Add(new ListViewSubItem(this, "" + InEvent.SignInHour + ":" + InEvent.SignInMinute));
            this.SubItems.Add(new ListViewSubItem(this, "" + InEvent.SignOutHour + ":" + InEvent.SignOutMinute));
            this.SubItems.Add(new ListViewSubItem(this, "" + InEvent.TimeElapsed.TotalHours));
        }
    }

    class ListViewColumnSorter : IComparer
    {
        public enum SortMode
        {
            NumericMode,
            StringMode
        }

        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;

        public SortMode SortingMode;

        public ListViewColumnSorter(SortMode sortMode)
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            //set sort mode
            SortingMode = sortMode;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            if (SortingMode == SortMode.StringMode)
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            else
            {
                string xValue = listviewX.SubItems[ColumnToSort].Text;

                string yValue = listviewY.SubItems[ColumnToSort].Text;

                double xNumber, yNumber;

                if (Double.TryParse(xValue, out xNumber) && Double.TryParse(yValue, out yNumber))
                {
                    compareResult = xNumber.CompareTo(yNumber);
                } else
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                }
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}