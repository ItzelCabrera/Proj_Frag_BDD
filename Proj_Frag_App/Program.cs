using System;
using System.Windows.Forms;

namespace Proj_Frag_App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExecSQLfile ex = new ExecSQLfile();
            ex.runSqlScriptFile("../servers.sql");
            Application.Run(new frmRun());
        }
    }
}
