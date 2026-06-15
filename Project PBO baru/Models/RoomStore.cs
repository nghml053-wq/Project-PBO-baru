using System;

namespace Project_PBO_baru.Models
{
    // Simple in-memory store for room names with change notification.
    // Extended to optionally load/save to database (Postgres) if a "kamar" table
    // with columns (id_kamar, nomor_kamar, harga) exists. If DB is not present
    // or column missing, it falls back to in-memory defaults.
    public static class RoomStore
    {
        private static readonly string[] names = new string[]
        {
            "", // 0 unused
            "NamaKamar1",
            "NamaKamar2",
            "NamaKamar3",
            "NamaKamar4"
        };

        private static readonly string[] prices = new string[]
        {
            "", // 0 unused
            "100000",
            "150000",
            "200000",
            "250000"
        };

        // If rooms are loaded from DB, dbIds[i] contains corresponding id_kamar
        // otherwise 0.
        private static readonly int[] dbIds = new int[5];

        private static bool initialized = false;
        private static bool dbAvailable = false;
        private static readonly object initLock = new object();

        public static event Action<int, string> RoomNameChanged;
        public static event Action<int, string> RoomPriceChanged;

        private static void EnsureInitialized()
        {
            if (initialized) return;
            lock (initLock)
            {
                if (initialized) return;
                try
                {
                    // Try to load from DB using existing DBConnection class.
                    var db = new Project_PBO_baru.Database.DBConnection();
                    using (var conn = db.GetConnection())
                    {
                        conn.Open();
                        // Attempt to read id_kamar, nomor_kamar and harga (if exists)
                        using (var cmd = new Npgsql.NpgsqlCommand(
                            "SELECT id_kamar, nomor_kamar, COALESCE(harga::text, '') AS harga_text FROM kamar ORDER BY id_kamar LIMIT 4",
                            conn))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                int idx = 1;
                                while (reader.Read() && idx <= 4)
                                {
                                    try
                                    {
                                        int id = reader.IsDBNull(reader.GetOrdinal("id_kamar")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_kamar"));
                                        string nomor = reader.IsDBNull(reader.GetOrdinal("nomor_kamar")) ? string.Empty : reader.GetString(reader.GetOrdinal("nomor_kamar"));
                                        string harga = string.Empty;
                                        if (!reader.IsDBNull(reader.GetOrdinal("harga_text")))
                                            harga = reader.GetString(reader.GetOrdinal("harga_text"));

                                        dbIds[idx] = id;
                                        if (!string.IsNullOrEmpty(nomor)) names[idx] = nomor;
                                        if (!string.IsNullOrEmpty(harga)) prices[idx] = harga;
                                    }
                                    catch
                                    {
                                        // If any single row mapping fails, skip but continue
                                    }
                                    idx++;
                                }
                                dbAvailable = true;
                            }
                        }
                    }
                }
                catch
                {
                    // DB not available or schema different; stay with defaults
                    dbAvailable = false;
                }

                initialized = true;
            }
        }

        public static string GetName(int index)
        {
            EnsureInitialized();
            if (index < 1 || index > 4) return string.Empty;
            return names[index];
        }

        public static void SetName(int index, string value)
        {
            EnsureInitialized();
            if (index < 1 || index > 4) return;
            names[index] = value ?? string.Empty;
            RoomNameChanged?.Invoke(index, names[index]);

            // Persist to DB if possible
            if (dbAvailable && dbIds[index] != 0)
            {
                try
                {
                    var db = new Project_PBO_baru.Database.DBConnection();
                    using (var conn = db.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new Npgsql.NpgsqlCommand("UPDATE kamar SET nomor_kamar = @nomor WHERE id_kamar = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@nomor", names[index]);
                            cmd.Parameters.AddWithValue("@id", dbIds[index]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                    // ignore DB errors, keep in-memory state
                }
            }
        }

        public static string GetPrice(int index)
        {
            EnsureInitialized();
            if (index < 1 || index > 4) return string.Empty;
            return prices[index];
        }

        public static void SetPrice(int index, string value)
        {
            EnsureInitialized();
            if (index < 1 || index > 4) return;
            prices[index] = value ?? string.Empty;
            RoomPriceChanged?.Invoke(index, prices[index]);

            // Persist to DB if possible and if kamar table has harga column
            if (dbAvailable && dbIds[index] != 0)
            {
                try
                {
                    var db = new Project_PBO_baru.Database.DBConnection();
                    using (var conn = db.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new Npgsql.NpgsqlCommand("UPDATE kamar SET harga = @harga WHERE id_kamar = @id", conn))
                        {
                            // store as numeric if possible, otherwise as text
                            cmd.Parameters.AddWithValue("@harga", prices[index]);
                            cmd.Parameters.AddWithValue("@id", dbIds[index]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                    // ignore DB errors (missing column etc.)
                }
            }
        }
    }
}
