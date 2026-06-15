using Project_PBO_baru.View.Auth;
using System;
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
    public partial class DashboardAdmincs : Form
    {
        public DashboardAdmincs()
        {
            InitializeComponent();
            this.Load += DashboardAdmincs_Load;
        }

        private void DashboardAdmincs_Load(object sender, EventArgs e)
        {
            try
            {
                // add summary boxes dynamically
                int totalCustomers = Project_PBO_baru.Services.ReportingService.GetTotalCustomers();
                decimal totalRevenue = Project_PBO_baru.Services.ReportingService.GetTotalRevenue();
                int totalReservations = Project_PBO_baru.Services.ReportingService.GetTotalReservations();

                var lblCust = new Label() { Left = 220, Top = 20, Width = 200, Height = 30, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), Text = $"Customers: {totalCustomers}" };
                var lblRevenue = new Label() { Left = 420, Top = 20, Width = 220, Height = 30, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), Text = $"Revenue: {totalRevenue:C}" };
                var lblResv = new Label() { Left = 220, Top = 60, Width = 200, Height = 30, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), Text = $"Reservations: {totalReservations}" };

                this.Controls.Add(lblCust);
                this.Controls.Add(lblRevenue);
                this.Controls.Add(lblResv);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DashboardAdmincs_Load error: " + ex);
            }
        }

        private void BtnLogoutAdm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void BtnLaporanAdm_Click(object sender, EventArgs e)
        {
            LaporanForm laporanForm = new LaporanForm();
            laporanForm.Show();
            this.Hide();
        }
        private void ReservasiAdm_Click(object sender, EventArgs e)
        {
            KelolaReservasiForm kelolaReservasiForm = new KelolaReservasiForm();
            kelolaReservasiForm.Show();
            this.Hide();
        }

        private void BtnJenisKamarAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnDataKamarAdm_Click(object sender, EventArgs e)
        {
            KelolaKamarForm kelolaKamarForm = new KelolaKamarForm();
            kelolaKamarForm.Show();
            this.Hide();
        }

        private void BtnDataUserAdm_Click(object sender, EventArgs e)
        {
            KelolaCustomer kelolaCustomer = new KelolaCustomer();
            kelolaCustomer .Show();
            this.Hide();
        }

        private void BtnDashboardAdm_Click(object sender, EventArgs e)
        {

        }

        private void GrafikTotalReservasi_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = Project_PBO_baru.Services.ReportingService.GetLast30DaysSummary();
                // prepare chart
                var chart = this.GrafikTotalReservasi;
                chart.Series.Clear();

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Reservations");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chart.Series.Add(series);

                // order by date ascending for a sensible timeline
                foreach (var r in rows.OrderBy(x => x.Date))
                {
                    series.Points.AddXY(r.Date.ToString("yyyy-MM-dd"), r.Count);
                }

                chart.Invalidate();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GrafikTotalReservasi_Click error: " + ex);
            }
        }
    }
}
