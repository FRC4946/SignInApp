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
    public partial class PasswordForm : Form
    {
        public bool PasswordEntered = false;

        public PasswordForm()
        {
            InitializeComponent();
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            PasswordEntered = DriveInteraction.Interactions.AuthenticatePassword(passwordText.Text);
            if (PasswordEntered) //close window if password entered successfully
            {
                //setup encryption
                MainProgram.AppState.SystemAes = Encryption.Encryptors.LoadKeyFromPassword(passwordText.Text);

                //close
                this.Close();
            } else //incorrect password
            {
                passwordText.Text = "";
                incorrectPasswordLabel.Visible = true;
                passwordText.Focus();
            }
        }
    }
}
