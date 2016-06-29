using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CApplication = System.Windows.Forms.Application;

class Program
{
    static void Main(string[] args)
    {
        CApplication.EnableVisualStyles();
        CApplication.SetCompatibleTextRenderingDefault(false);
        CApplication.Run(new MainForm());
    }
}
