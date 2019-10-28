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
    public partial class DeleteMemberForm : Form
    {
        public DeleteMemberForm()
        {
            InitializeComponent();
        }

        private void memberButton_Click(object sender, EventArgs e)
        {
            int number;
            if (Int32.TryParse(memberBox.Text, out number))
            {
                Member member = DriveInteraction.Interactions.LookupMember(number);
                if (member != null)
                {
                    DriveInteraction.Interactions.DeleteMember(member.Number);
                    this.Close();
                } else
                {
                    invalidMemberLabel.Visible = true;
                    memberBox.Text = "";
                }
            } else //show error
            {
                invalidMemberLabel.Visible = true;
                memberBox.Text = "";
            }
        }
    }
}
