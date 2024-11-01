using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Window inputScreen = new Window();

            Application.Run(inputScreen);

            //if (inputScreen.Authentication_success) Application.Run(new gameArea());
        }
    }
}