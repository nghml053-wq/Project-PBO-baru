using System;
using System.Collections.Generic;
using Npgsql;
using Project_PBO_baru.Database;
using Project_PBO_baru.Models;

namespace Project_PBO_baru.Services
{
    public static class UserService
    {
        public static User GetUserById(int userId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"
SELECT id_user, username, nama_user, no_hp, role_user_id
FROM ""user""
WHERE id_user = @id
LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id_user"));
                                string username = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string namaUser = reader.IsDBNull(reader.GetOrdinal("nama_user")) ? "" : reader.GetString(reader.GetOrdinal("nama_user"));
                                int noHp = reader.IsDBNull(reader.GetOrdinal("no_hp")) ? 0 : reader.GetInt32(reader.GetOrdinal("no_hp"));
                                int roleUserId = reader.IsDBNull(reader.GetOrdinal("role_user_id")) ? 2 : reader.GetInt32(reader.GetOrdinal("role_user_id"));

                                return new User
                                {
                                    IdUser = id,
                                    Username = username,
                                    NamaUser = namaUser,
                                    NoHp = noHp,
                                    RoleUserId = roleUserId
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UserService.GetUserById error: " + ex);
            }
            return null;
        }

        public static User GetUserByUsername(string username)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(@"
SELECT id_user, username, nama_user, no_hp, role_user_id
FROM ""user""
WHERE username = @username
LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id_user"));
                                string uname = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string namaUser = reader.IsDBNull(reader.GetOrdinal("nama_user")) ? "" : reader.GetString(reader.GetOrdinal("nama_user"));
                                int noHp = reader.IsDBNull(reader.GetOrdinal("no_hp")) ? 0 : reader.GetInt32(reader.GetOrdinal("no_hp"));
                                int roleUserId = reader.IsDBNull(reader.GetOrdinal("role_user_id")) ? 2 : reader.GetInt32(reader.GetOrdinal("role_user_id"));

                                return new User
                                {
                                    IdUser = id,
                                    Username = uname,
                                    NamaUser = namaUser,
                                    NoHp = noHp,
                                    RoleUserId = roleUserId
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UserService.GetUserByUsername error: " + ex);
            }
            return null;
        }

        public static List<User> GetAllUsers()
        {
            var list = new List<User>();
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id_user, username, nama_user, no_hp, role_user_id FROM \"user\" ORDER BY id_user DESC", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.IsDBNull(reader.GetOrdinal("id_user")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_user"));
                                string uname = reader.IsDBNull(reader.GetOrdinal("username")) ? "" : reader.GetString(reader.GetOrdinal("username"));
                                string namaUser = reader.IsDBNull(reader.GetOrdinal("nama_user")) ? "" : reader.GetString(reader.GetOrdinal("nama_user"));
                                int noHp = reader.IsDBNull(reader.GetOrdinal("no_hp")) ? 0 : reader.GetInt32(reader.GetOrdinal("no_hp"));
                                int roleUserId = reader.IsDBNull(reader.GetOrdinal("role_user_id")) ? 2 : reader.GetInt32(reader.GetOrdinal("role_user_id"));

                                list.Add(new User { IdUser = id, Username = uname, NamaUser = namaUser, NoHp = noHp, RoleUserId = roleUserId });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UserService.GetAllUsers error: " + ex);
            }
            return list;
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM \"user\" WHERE id_user = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        int affected = cmd.ExecuteNonQuery();
                        return affected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UserService.DeleteUser error: " + ex);
                return false;
            }
        }

        public static bool UserHasActivity(int userId)
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    // Check reservasi
                    using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM reservasi WHERE user_id_user = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        var obj = cmd.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value && Convert.ToInt32(obj) > 0) return true;
                    }

                    // Check transaksi via reservasi
                    using (var cmd2 = new NpgsqlCommand(@"SELECT COUNT(*) FROM transaksi t JOIN reservasi r ON t.reservasi_id_reservasi = r.id_reservasi WHERE r.user_id_user = @id", conn))
                    {
                        cmd2.Parameters.AddWithValue("@id", userId);
                        var obj2 = cmd2.ExecuteScalar();
                        if (obj2 != null && obj2 != DBNull.Value && Convert.ToInt32(obj2) > 0) return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UserService.UserHasActivity error: " + ex);
                // Be conservative: if we can't verify, prevent deletion
                return true;
            }
            return false;
        }
    }
}
