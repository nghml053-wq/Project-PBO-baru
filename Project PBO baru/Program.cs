using System;
using System.Windows.Forms;
using Project_PBO_baru.View.Auth;

namespace Project_PBO_baru
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args) // <--- UBAH BARIS INI (Tambahkan string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}