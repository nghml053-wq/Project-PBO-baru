using System;
using System.Collections.Generic;
using Npgsql;
using Project_PBO_baru.Database;

namespace Project_PBO_baru.Services
{
    public class RoomInfo
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
    }

    public static class RoomService
    {
        public static List<RoomInfo> GetAllRooms()
        {
            var list = new List<RoomInfo>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id_kamar, nomor_kamar, COALESCE(harga,0) as harga FROM kamar ORDER BY id_kamar", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_kamar"));
                                string nomor = reader.IsDBNull(reader.GetOrdinal("nomor_kamar")) ? "" : reader.GetString(reader.GetOrdinal("nomor_kamar"));
                                decimal harga = reader.IsDBNull(reader.GetOrdinal("harga")) ? 0m : reader.GetDecimal(reader.GetOrdinal("harga"));
                                list.Add(new RoomInfo { Id = id, Number = nomor, Price = harga });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RoomService.GetAllRooms error: " + ex);
            }
            return list;
        }

        public static bool CreateRoom(string number, decimal price)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("INSERT INTO kamar (nomor_kamar, harga, status_kamar) VALUES (@nomor, @harga, 'tersedia')", conn))
                    {
                        cmd.Parameters.AddWithValue("@nomor", number);
                        cmd.Parameters.AddWithValue("@harga", price);
                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RoomService.CreateRoom error: " + ex);
                return false;
            }
        }
    }
}
