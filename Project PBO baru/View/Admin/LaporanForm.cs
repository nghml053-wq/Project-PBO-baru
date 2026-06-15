using Project_PBO_baru.View.Auth;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PBO_baru.View.Admin
{
    public partial class LaporanForm : Form
    {
        public LaporanForm()
        {
            InitializeComponent();
            this.Load += LaporanForm_Load;
        }

        private System.Windows.Forms.DateTimePicker DtStart;
        private System.Windows.Forms.DateTimePicker DtEnd;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Button BtnExportCsv;
        private System.Windows.Forms.DataGridView DgvReport;
        private System.Collections.Generic.List<Project_PBO_baru.Services.DailySummary> _lastRows;
        private System.Windows.Forms.Label LblTotals;

        private void LaporanForm_Load(object sender, EventArgs e)
        {
            // build simple UI for report selection
            DtStart = new DateTimePicker() { Left = 160, Top = 20, Width = 160 };
            DtEnd = new DateTimePicker() { Left = 340, Top = 20, Width = 160 };
            BtnGenerate = new Button() { Left = 520, Top = 20, Width = 80, Text = "Generate" };
            BtnGenerate.Click += BtnGenerate_Click;
            BtnExportCsv = new Button() { Left = 610, Top = 20, Width = 90, Text = "Export CSV" };
            BtnExportCsv.Click += BtnExportCsv_Click;

            DgvReport = new DataGridView() { Left = 160, Top = 60, Width = 440, Height = 300, ReadOnly = true, AllowUserToAddRows = false };

            // totals label below grid
            LblTotals = new Label() { Left = 160, Top = 370, Width = 440, Height = 24, Text = "", Visible = true };

            this.Controls.Add(DtStart);
            this.Controls.Add(DtEnd);
            this.Controls.Add(BtnGenerate);
            this.Controls.Add(BtnExportCsv);
            this.Controls.Add(DgvReport);
            this.Controls.Add(LblTotals);

            // sensible defaults
            DtStart.Value = DateTime.Today.AddDays(-30);
            DtEnd.Value = DateTime.Today;
            DgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var start = DtStart.Value.Date;
                var end = DtEnd.Value.Date;
                if (end < start)
                {
                    MessageBox.Show("End date must be same or after start date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rows = Project_PBO_baru.Services.ReportingService.GetSummaryBetween(start, end);
                _lastRows = rows;
                var dgv = DgvReport;
                dgv.Columns.Clear();
                dgv.Rows.Clear();
                dgv.Columns.Add("Date", "Date");
                dgv.Columns.Add("Reservations", "Reservations");
                dgv.Columns.Add("Revenue", "Revenue");

                int totalRes = 0;
                decimal totalRev = 0m;
                foreach (var r in rows)
                {
                    dgv.Rows.Add(r.Date.ToString("yyyy-MM-dd"), r.Count, r.Total.ToString("C"));
                    totalRes += r.Count;
                    totalRev += r.Total;
                }

                if (rows == null || rows.Count == 0)
                {
                    MessageBox.Show("No report data for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LblTotals.Text = "";
                }
                else
                {
                    LblTotals.Text = $"Total reservations: {totalRes}    Total revenue: {totalRev:C}";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("BtnGenerate_Click error: " + ex);
            }
        }

        private void BtnDashboardAdm_Click(object sender, EventArgs e)
        {
            DashboardAdmincs dashboardAdmincs = new DashboardAdmincs();
            dashboardAdmincs.Show();
            this.Hide();
        }

        private void BtnDataUserAdm_Click(object sender, EventArgs e)
        {
            KelolaCustomer kelolaCustomer = new KelolaCustomer();
            kelolaCustomer.Show();
            this.Hide();
        }

        private void BtnDataKamarAdm_Click(object sender, EventArgs e)
        {
            KelolaKamarForm kelolaKamarForm = new KelolaKamarForm();
            kelolaKamarForm.Show();
            this.Hide();
        }

        private void BtnJenisKamarAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnReservasiAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnTransaksiAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogoutAdm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void BtnCetakPDFAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lastRows == null || _lastRows.Count == 0)
                {
                    MessageBox.Show("No report data to export. Please generate a report first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FileName = $"laporan_{DtStart.Value:yyyyMMdd}_{DtEnd.Value:yyyyMMdd}.csv";
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    using (var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // header
                        sw.WriteLine("Date,Reservations,Revenue");
                        int totalRes = 0;
                        decimal totalRev = 0m;
                        foreach (var r in _lastRows)
                        {
                            sw.WriteLine($"{r.Date:yyyy-MM-dd},{r.Count},{r.Total}");
                            totalRes += r.Count;
                            totalRev += r.Total;
                        }

                        // totals row
                        sw.WriteLine($",{totalRes},{totalRev}");
                    }

                    MessageBox.Show("CSV exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("BtnExportCsv_Click error: " + ex);
                MessageBox.Show("Failed to export CSV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
