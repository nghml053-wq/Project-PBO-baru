using System;

namespace Project_PBO_baru.Database
{
    internal static class SchemaMigrator
    {
        public static void EnsureSchema()
        {
            try
            {
                var db = new DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        // Add harga column to kamar if missing, with a sensible default
                        cmd.CommandText = @"ALTER TABLE kamar ADD COLUMN IF NOT EXISTS harga NUMERIC DEFAULT 100000;";
                        cmd.ExecuteNonQuery();

                        // Ensure existing rows have a numeric harga value
                        cmd.CommandText = @"UPDATE kamar SET harga = 100000 WHERE harga IS NULL;";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                // Ignore migration failures: application will continue using in-memory fallback.
            }
        }
    }
}
