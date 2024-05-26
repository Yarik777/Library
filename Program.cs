using LibraryManagement;
using System;
using System.Windows.Forms;
using Бібліотека.UI;

namespace Бібліотека
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
