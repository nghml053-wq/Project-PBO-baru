using System;
using System.Collections.Generic;
using Project_PBO_baru.Models;

namespace Project_PBO_baru.Services
{
    internal static class PaymentService
    {
        public static List<PaymentMethod> GetAll()
        {
            var list = new List<PaymentMethod>();
            try
            {
                var db = new Project_PBO_baru.Database.DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new Npgsql.NpgsqlCommand("SELECT id_metode, nama_metode FROM metode_pembayaran ORDER BY id_metode", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("id_metode")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_metode"));
                                string name = reader.IsDBNull(reader.GetOrdinal("nama_metode")) ? string.Empty : reader.GetString(reader.GetOrdinal("nama_metode"));
                                list.Add(new PaymentMethod { Id = id, Name = name });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PaymentService.GetAll error: " + ex);
                // fallback methods
                list.Add(new PaymentMethod { Id = 1, Name = "Metode 1" });
                list.Add(new PaymentMethod { Id = 2, Name = "Metode 2" });
            }
            return list;
        }
    }
}
