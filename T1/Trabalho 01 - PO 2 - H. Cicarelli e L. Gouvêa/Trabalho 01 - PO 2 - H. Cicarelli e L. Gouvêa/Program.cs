using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trabalho_01___PO_2___H.Cicarelli_e_L.Gouvêa
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
