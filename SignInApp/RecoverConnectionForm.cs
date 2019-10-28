using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApp
{
    public partial class RecoverConnectionForm : Form
    {

        public bool CloseApp = false;

        public RecoverConnectionForm()
        {
            InitializeComponent();
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeAppButton_Click(object sender, EventArgs e)
        {
            CloseApp = true;
            Process.GetCurrentProcess().Kill();
        }
    }
}
