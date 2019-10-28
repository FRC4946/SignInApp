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
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (firstNameBox.Text == "" || lastNameBox.Text == "" || numberBox.Text == "")
            {
                errorLabel.Text = "Please Fill Out All Fields";
                errorLabel.Visible = true;
            }
            else
            {
                int number;
                if (Int32.TryParse(numberBox.Text, out number))
                {
                    DriveInteraction.Interactions.RegisterMember(number, firstNameBox.Text, lastNameBox.Text);
                    this.Close();
                } else
                {
                    errorLabel.Text = "Please Enter A Valid Number";
                    errorLabel.Visible = true;
                }
            }
        }
    }
}
