using SignInApp.WindowInteraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApp
{
    public partial class InfoForm : Form
    {
        private ListViewColumnSorter eventListSorter = new ListViewColumnSorter(ListViewColumnSorter.SortMode.NumericMode);
        public Member Member;
        public SignInEventList SignEventList;

        public InfoForm(Member member)
        {
            //initialize properties
            Member = member;
            SignEventList = MainProgram.AppState.SignedOut.GetEventsByNumber(Member.Number);

            //initialize components
            InitializeComponent();

            //set components
            eventList.ListViewItemSorter = eventListSorter;
            updateEventList();

            firstNameSpace.Text = Member.FirstName;
            lastNameSpace.Text = Member.LastName;
            numberSpace.Text = "" + Member.Number;
            hoursSpace.Text = "" + SignEventList.SumTime().TotalHours;
        }

        private void updateEventList()
        {
            eventList.Items.Clear();
            foreach (SignInEvent inEvent in SignEventList.EventList)
            {
                eventList.Items.Add(new SignInListItem(inEvent));
            }
        }

        private void eventList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader header = eventList.Columns[e.Column];

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == eventListSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (eventListSorter.Order == SortOrder.Ascending)
                {
                    eventListSorter.Order = SortOrder.Descending;
                }
                else
                {
                    eventListSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                eventListSorter.SortColumn = e.Column;
                eventListSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            eventList.Sort();
        }
    }
}
