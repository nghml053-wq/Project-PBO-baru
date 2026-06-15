using System;
using System.Collections.Generic;
using Npgsql;
using Project_PBO_baru.Database;
using Project_PBO_baru.Models;

namespace Project_PBO_baru.Services
{
    public static class ReservationService
    {
        public static event Action ReservationsChanged;

        public static List<Reservation> GetReservationsByUser(int userId)
        {
            var list = new List<Reservation>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"SELECT r.id_reservasi, r.tanggal_checkin, r.tanggal_checkout, t.total_bayar, r.status_reservasi, dr.kamar_id_kamar, k.nomor_kamar, k.status_kamar as room_status, u.id_user, u.username
FROM reservasi r
LEFT JOIN transaksi t ON t.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN detail_reservasi dr ON dr.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN kamar k ON dr.kamar_id_kamar = k.id_kamar
LEFT JOIN ""user"" u ON r.user_id_user = u.id_user
WHERE r.user_id_user = @user ORDER BY r.id_reservasi DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@user", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("id_reservasi")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_reservasi"));
                                DateTime ci = reader.IsDBNull(reader.GetOrdinal("tanggal_checkin")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkin"));
                                DateTime co = reader.IsDBNull(reader.GetOrdinal("tanggal_checkout")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkout"));
                                decimal total = reader.IsDBNull(reader.GetOrdinal("total_bayar")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total_bayar"));
                                string status = reader.IsDBNull(reader.GetOrdinal("status_reservasi")) ? "" : reader.GetString(reader.GetOrdinal("status_reservasi"));
                                int roomId = reader.IsDBNull(reader.GetOrdinal("kamar_id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("kamar_id_kamar"));
                                string roomName = reader.IsDBNull(reader.GetOrdinal("nomor_kamar")) ? "" : reader.GetString(reader.GetOrdinal("nomor_kamar"));
                                int uid = reader.IsDBNull(reader.GetOrdinal("id_user")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_user"));
                                string username = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string roomStatus = reader.IsDBNull(reader.GetOrdinal("room_status")) ? "" : reader.GetString(reader.GetOrdinal("room_status"));

                                list.Add(Reservation.Create(id, ci, co, total, status, roomId, roomName, uid, username, roomStatus));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetReservationsByUser error: " + ex);
                // ignore and return empty list on DB error
            }

            return list;
        }

        public static List<Reservation> GetAllReservations()
        {
            var list = new List<Reservation>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"SELECT r.id_reservasi, r.tanggal_checkin, r.tanggal_checkout, t.total_bayar, r.status_reservasi, dr.kamar_id_kamar, k.nomor_kamar, k.status_kamar as room_status, u.id_user, u.username
FROM reservasi r
LEFT JOIN transaksi t ON t.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN detail_reservasi dr ON dr.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN kamar k ON dr.kamar_id_kamar = k.id_kamar
LEFT JOIN ""user"" u ON r.user_id_user = u.id_user
ORDER BY r.id_reservasi DESC", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("id_reservasi")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_reservasi"));
                                DateTime ci = reader.IsDBNull(reader.GetOrdinal("tanggal_checkin")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkin"));
                                DateTime co = reader.IsDBNull(reader.GetOrdinal("tanggal_checkout")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkout"));
                                decimal total = reader.IsDBNull(reader.GetOrdinal("total_bayar")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total_bayar"));
                                string status = reader.IsDBNull(reader.GetOrdinal("status_reservasi")) ? "" : reader.GetString(reader.GetOrdinal("status_reservasi"));
                                int roomId = reader.IsDBNull(reader.GetOrdinal("kamar_id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("kamar_id_kamar"));
                                string roomName = reader.IsDBNull(reader.GetOrdinal("nomor_kamar")) ? "" : reader.GetString(reader.GetOrdinal("nomor_kamar"));
                                int uid = reader.IsDBNull(reader.GetOrdinal("id_user")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_user"));
                                string username = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string roomStatus = reader.IsDBNull(reader.GetOrdinal("room_status")) ? "" : reader.GetString(reader.GetOrdinal("room_status"));

                                list.Add(Reservation.Create(id, ci, co, total, status, roomId, roomName, uid, username, roomStatus));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetAllReservations error: " + ex);
            }
            return list;
        }

        public static Reservation GetReservationById(int id)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"SELECT r.id_reservasi, r.tanggal_checkin, r.tanggal_checkout, t.total_bayar, r.status_reservasi, dr.kamar_id_kamar, k.nomor_kamar, k.status_kamar as room_status, r.user_id_user, u.username
FROM reservasi r
LEFT JOIN transaksi t ON t.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN detail_reservasi dr ON dr.reservasi_id_reservasi = r.id_reservasi
LEFT JOIN kamar k ON dr.kamar_id_kamar = k.id_kamar
LEFT JOIN ""user"" u ON r.user_id_user = u.id_user
WHERE r.id_reservasi = @id LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int rid = reader.IsDBNull(reader.GetOrdinal("id_reservasi")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_reservasi"));
                                DateTime ci = reader.IsDBNull(reader.GetOrdinal("tanggal_checkin")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkin"));
                                DateTime co = reader.IsDBNull(reader.GetOrdinal("tanggal_checkout")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_checkout"));
                                decimal total = reader.IsDBNull(reader.GetOrdinal("total_bayar")) ? 0m : reader.GetDecimal(reader.GetOrdinal("total_bayar"));
                                string status = reader.IsDBNull(reader.GetOrdinal("status_reservasi")) ? "" : reader.GetString(reader.GetOrdinal("status_reservasi"));
                                int roomId = reader.IsDBNull(reader.GetOrdinal("kamar_id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("kamar_id_kamar"));
                                string roomName = reader.IsDBNull(reader.GetOrdinal("nomor_kamar")) ? "" : reader.GetString(reader.GetOrdinal("nomor_kamar"));
                                int uid = reader.IsDBNull(reader.GetOrdinal("user_id_user")) ? 0 : reader.GetInt32(reader.GetOrdinal("user_id_user"));
                                string username = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string roomStatus = reader.IsDBNull(reader.GetOrdinal("room_status")) ? "" : reader.GetString(reader.GetOrdinal("room_status"));

                                return Reservation.Create(rid, ci, co, total, status, roomId, roomName, uid, username, roomStatus);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetReservationById error: " + ex);
                // ignore
            }
            return null;
        }

        public static bool UpdateReservationDates(int reservationId, DateTime newCheckIn, DateTime newCheckOut)
        {
            try
            {
                if (newCheckOut <= newCheckIn) return false;

                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        int roomId = 0;
                        decimal harga = 0m;

                        // get room id and price from detail_reservasi for this reservation
                        using (var cmd = new NpgsqlCommand(@"SELECT kamar_id_kamar, harga_kamar FROM detail_reservasi WHERE reservasi_id_reservasi = @id LIMIT 1", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    roomId = reader.IsDBNull(reader.GetOrdinal("kamar_id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("kamar_id_kamar"));
                                    harga = reader.IsDBNull(reader.GetOrdinal("harga_kamar")) ? 0m : reader.GetDecimal(reader.GetOrdinal("harga_kamar"));
                                }
                            }
                        }

                        if (roomId == 0) { tran.Rollback(); return false; }

                        // Check availability excluding this reservation
                        using (var cmd = new NpgsqlCommand(@"
SELECT COUNT(*) FROM reservasi r
JOIN detail_reservasi dr ON dr.reservasi_id_reservasi = r.id_reservasi
WHERE dr.kamar_id_kamar = @id
  AND r.status_reservasi != 'dibatalkan'
  AND r.id_reservasi != @resid
  AND NOT (r.tanggal_checkout <= @ci OR r.tanggal_checkin >= @co)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", roomId);
                            cmd.Parameters.AddWithValue("@ci", newCheckIn.Date);
                            cmd.Parameters.AddWithValue("@co", newCheckOut.Date);
                            cmd.Parameters.AddWithValue("@resid", reservationId);
                            var obj = cmd.ExecuteScalar();
                            int cnt = 0;
                            if (obj != null && obj != DBNull.Value) cnt = Convert.ToInt32(obj);
                            if (cnt > 0) { tran.Rollback(); return false; }
                        }

                        // update reservasi dates
                        using (var cmd = new NpgsqlCommand("UPDATE reservasi SET tanggal_checkin = @ci, tanggal_checkout = @co WHERE id_reservasi = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@ci", newCheckIn.Date);
                            cmd.Parameters.AddWithValue("@co", newCheckOut.Date);
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            cmd.ExecuteNonQuery();
                        }

                        // recalc total based on harga and nights, update transaksi
                        int nights = (int)(newCheckOut.Date - newCheckIn.Date).TotalDays;
                        decimal total = harga * Math.Max(1, nights);
                        using (var cmd = new NpgsqlCommand("UPDATE transaksi SET total_bayar = @total WHERE reservasi_id_reservasi = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }

                ReservationsChanged?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.UpdateReservationDates error: " + ex);
                return false;
            }
        }

        public static bool CreateReservation(int userId, int roomId, DateTime checkin, DateTime checkout, int jumlahTamu, int metodeId)
        {
            try
            {
                // validate dates: checkout must be after checkin
                if (checkout <= checkin)
                {
                    System.Diagnostics.Debug.WriteLine($"ReservationService.CreateReservation: invalid dates {checkin} - {checkout}");
                    return false;
                }
                // check availability first
                if (!IsRoomAvailable(roomId, checkin, checkout))
                {
                    System.Diagnostics.Debug.WriteLine($"ReservationService.CreateReservation: room {roomId} not available {checkin} - {checkout}");
                    return false;
                }
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // get price from kamar
                        decimal harga = 0m;
                        using (var cmd = new NpgsqlCommand("SELECT harga FROM kamar WHERE id_kamar = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", roomId);
                            var obj = cmd.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                                harga = Convert.ToDecimal(obj);
                            else
                                harga = 0m;
                        }

                        // insert reservasi
                        int idReservasi = 0;
                        using (var cmd = new NpgsqlCommand(@"INSERT INTO reservasi (tanggal_checkin, tanggal_checkout, jumlah_tamu, status_reservasi, tanggal_pesan, user_id_user)
VALUES (@ci, @co, @tamu, 'pending', CURRENT_DATE, @user) RETURNING id_reservasi", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@ci", checkin.Date);
                            cmd.Parameters.AddWithValue("@co", checkout.Date);
                            cmd.Parameters.AddWithValue("@tamu", jumlahTamu);
                            cmd.Parameters.AddWithValue("@user", userId);
                            idReservasi = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // insert detail_reservasi
                        using (var cmd = new NpgsqlCommand(@"INSERT INTO detail_reservasi (harga_kamar, jumlah_kamar, status_kamar, reservasi_id_reservasi, kamar_id_kamar)
VALUES (@harga, 1, 'dipesan', @resid, @kamar)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@harga", harga);
                            cmd.Parameters.AddWithValue("@resid", idReservasi);
                            cmd.Parameters.AddWithValue("@kamar", roomId);
                            cmd.ExecuteNonQuery();
                        }

                        // insert transaksi
                        int nights = (int)(checkout.Date - checkin.Date).TotalDays;
                        decimal total = harga * Math.Max(1, nights);
                        using (var cmd = new NpgsqlCommand(@"INSERT INTO transaksi (tanggal_bayar, total_bayar, status_transaksi, reservasi_id_reservasi, metode_pembayaran_id_metode)
VALUES (CURRENT_DATE, @total, 'belum_bayar', @resid, @metode)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@resid", idReservasi);
                            cmd.Parameters.AddWithValue("@metode", metodeId);
                            cmd.ExecuteNonQuery();
                        }

                        // update kamar status
                        using (var cmd = new NpgsqlCommand("UPDATE kamar SET status_kamar = 'dipesan' WHERE id_kamar = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", roomId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }

                ReservationsChanged?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.CreateReservation error: " + ex);
                return false;
            }
        }

        public static bool CreateReservationByRoomNumber(int userId, string roomNumber, DateTime checkin, DateTime checkout, int jumlahTamu, int metodeId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id_kamar FROM kamar WHERE nomor_kamar = @nomor LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@nomor", roomNumber);
                        var obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value) return false;
                        int roomId = Convert.ToInt32(obj);
                        return CreateReservation(userId, roomId, checkin, checkout, jumlahTamu, metodeId);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.CreateReservationByRoomNumber error: " + ex);
                return false;
            }
        }

        public static int? GetRoomIdByNumber(string roomNumber)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id_kamar FROM kamar WHERE nomor_kamar = @nomor LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@nomor", roomNumber);
                        var obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value) return null;
                        return Convert.ToInt32(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetRoomIdByNumber error: " + ex);
            }
            return null;
        }

        public static bool IsRoomAvailable(int roomId, DateTime checkin, DateTime checkout)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"
SELECT COUNT(*) FROM reservasi r
JOIN detail_reservasi dr ON dr.reservasi_id_reservasi = r.id_reservasi
WHERE dr.kamar_id_kamar = @id
  AND r.status_reservasi != 'dibatalkan'
  AND NOT (r.tanggal_checkout <= @ci OR r.tanggal_checkin >= @co)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", roomId);
                        cmd.Parameters.AddWithValue("@ci", checkin.Date);
                        cmd.Parameters.AddWithValue("@co", checkout.Date);
                        var obj = cmd.ExecuteScalar();
                        int cnt = 0;
                        if (obj != null && obj != DBNull.Value) cnt = Convert.ToInt32(obj);
                        return cnt == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.IsRoomAvailable error: " + ex);
                // if error, be conservative and return false (not available)
                return false;
            }
        }

        public static decimal? GetRoomPriceById(int roomId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT harga FROM kamar WHERE id_kamar = @id LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", roomId);
                        var obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value) return null;
                        return Convert.ToDecimal(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetRoomPriceById error: " + ex);
            }
            return null;
        }

        public static decimal? GetRoomPriceByNumber(string roomNumber)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT harga FROM kamar WHERE nomor_kamar = @nomor LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@nomor", roomNumber);
                        var obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value) return null;
                        return Convert.ToDecimal(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.GetRoomPriceByNumber error: " + ex);
            }
            return null;
        }

        public static bool CancelReservation(int reservationId, int userId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        // verify ownership
                        using (var cmd = new NpgsqlCommand("SELECT user_id_user FROM reservasi WHERE id_reservasi = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            var obj = cmd.ExecuteScalar();
                            if (obj == null || obj == DBNull.Value) return false;
                            int uid = Convert.ToInt32(obj);
                            if (uid != userId) return false;
                        }

                        // set reservasi status
                        using (var cmd = new NpgsqlCommand("UPDATE reservasi SET status_reservasi = 'dibatalkan' WHERE id_reservasi = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            cmd.ExecuteNonQuery();
                        }

                        // set transaksi refund
                        using (var cmd = new NpgsqlCommand("UPDATE transaksi SET status_transaksi = 'refund' WHERE reservasi_id_reservasi = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            cmd.ExecuteNonQuery();
                        }

                        // set kamar to tersedia for related kamar
                        using (var cmd = new NpgsqlCommand(@"UPDATE kamar SET status_kamar = 'tersedia' WHERE id_kamar IN (
    SELECT kamar_id_kamar FROM detail_reservasi WHERE reservasi_id_reservasi = @id
)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", reservationId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                }

                ReservationsChanged?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationService.CancelReservation error: " + ex);
                return false;
            }
        }
    }
}
