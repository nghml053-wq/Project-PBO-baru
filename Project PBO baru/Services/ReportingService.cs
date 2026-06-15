using System;
using System.Collections.Generic;
using Npgsql;
using Project_PBO_baru.Database;

namespace Project_PBO_baru.Services
{
    public class DailySummary
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
    }

    public static class ReportingService
    {
        public static List<DailySummary> GetLast30DaysSummary()
        {
            var list = new List<DailySummary>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"
SELECT date_trunc('day', r.tanggal_pesan) as day,
       count(*) as cnt,
       coalesce(sum(t.total_bayar),0) as total
FROM reservasi r
LEFT JOIN transaksi t ON t.reservasi_id_reservasi = r.id_reservasi
WHERE r.tanggal_pesan >= CURRENT_DATE - INTERVAL '29 days'
GROUP BY day
ORDER BY day DESC", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var dt = reader.GetDateTime(reader.GetOrdinal("day"));
                                int cnt = reader.IsDBNull(reader.GetOrdinal("cnt")) ? 0 : reader.GetInt32(reader.GetOrdinal("cnt"));
                                decimal total = reader.IsDBNull(reader.GetOrdinal("total")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total"));
                                list.Add(new DailySummary { Date = dt, Count = cnt, Total = total });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReportingService.GetLast30DaysSummary error: " + ex);
            }
            return list;
        }

        public static List<DailySummary> GetSummaryBetween(DateTime startDate, DateTime endDate)
        {
            var list = new List<DailySummary>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"
SELECT date_trunc('day', r.tanggal_pesan) as day,
       count(*) as cnt,
       coalesce(sum(t.total_bayar),0) as total
FROM reservasi r
LEFT JOIN transaksi t ON t.reservasi_id_reservasi = r.id_reservasi
WHERE r.tanggal_pesan >= @start AND r.tanggal_pesan <= @end
GROUP BY day
ORDER BY day ASC", conn))
                    {
                        cmd.Parameters.AddWithValue("@start", startDate.Date);
                        cmd.Parameters.AddWithValue("@end", endDate.Date.AddDays(1).AddTicks(-1));
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var dt = reader.GetDateTime(reader.GetOrdinal("day"));
                                int cnt = reader.IsDBNull(reader.GetOrdinal("cnt")) ? 0 : reader.GetInt32(reader.GetOrdinal("cnt"));
                                decimal total = reader.IsDBNull(reader.GetOrdinal("total")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total"));
                                list.Add(new DailySummary { Date = dt, Count = cnt, Total = total });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReportingService.GetSummaryBetween error: " + ex);
            }
            return list;
        }

        public static int GetTotalCustomers()
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM \"user\"", conn))
                    {
                        var obj = cmd.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value) return Convert.ToInt32(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReportingService.GetTotalCustomers error: " + ex);
            }
            return 0;
        }

        public static decimal GetTotalRevenue()
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT coalesce(sum(total_bayar),0) FROM transaksi", conn))
                    {
                        var obj = cmd.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value) return Convert.ToDecimal(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReportingService.GetTotalRevenue error: " + ex);
            }
            return 0m;
        }

        public static int GetTotalReservations()
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM reservasi", conn))
                    {
                        var obj = cmd.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value) return Convert.ToInt32(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReportingService.GetTotalReservations error: " + ex);
            }
            return 0;
        }
    }
}
