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
    public partial class UpdatePasswordForm : Form
    {
        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (DriveInteraction.Interactions.AuthenticatePassword(oldPasswordBox.Text))
            {
                if (newPasswordBox.Text != "")
                {
                    if (newPasswordBox.Text == confirmNewPasswordBox.Text)
                    {
                        DriveInteraction.Interactions.UpdatePassword(newPasswordBox.Text);
                        this.Close();
                    } else
                    {
                        errorMessage.Text = "New Passwords Do Not Match, Please Try Again";
                        errorMessage.Visible = true;
                    }
                } else
                {
                    errorMessage.Text = "New Password Is Blank";
                    errorMessage.Visible = true;
                }
            } else
            {
                errorMessage.Text = "Incorrect Password, Please Try Again";
                errorMessage.Visible = true;
            }
        }
    }
}
