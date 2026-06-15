using System;
using System.Windows.Forms;
using System.Globalization;
using Project_PBO_baru.View.Admin;
using Project_PBO_baru.View.Auth;
using Project_PBO_baru.Database;

namespace Project_PBO_baru
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args) // <--- UBAH BARIS INI (Tambahkan string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Global exception handlers to surface unhandled errors during debugging/runtime
            Application.ThreadException += (s, e) => {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Unhandled UI thread exception: " + e.Exception);
                    MessageBox.Show("Unhandled error: " + e.Exception.Message + "\nSee Output (Debug) for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) => {
                try
                {
                    var ex = e.ExceptionObject as Exception;
                    System.Diagnostics.Debug.WriteLine("Unhandled domain exception: " + (ex?.ToString() ?? e.ExceptionObject.ToString()));
                    MessageBox.Show("Fatal error: " + (ex?.Message ?? e.ExceptionObject.ToString()) + "\nSee Output (Debug) for details.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch { }
            };

            // Set application-wide culture to Indonesian (Rupiah) so ToString("C") shows "Rp" and no cents
            var ci = new CultureInfo("id-ID");
            ci.NumberFormat.CurrencyDecimalDigits = 0;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            // Ensure DB schema (add harga column to kamar) so room prices can be persisted.
            SchemaMigrator.EnsureSchema();

            Application.Run(new LoginForm());
        }
    }
}