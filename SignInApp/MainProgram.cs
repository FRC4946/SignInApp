using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApp
{
    static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static DriveInteraction.AppState AppState = new DriveInteraction.AppState();    

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (WindowInteraction.Interactions.AuthenticatePasswordWindow()) 
                Application.Run(new MainWindow());
        }
    }
}
