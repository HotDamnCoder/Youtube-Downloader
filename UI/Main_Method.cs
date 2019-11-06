using System;
using System.Windows.Forms;

namespace UI
{
   
    static class Main_Method
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserI());
        }
    }
    
}