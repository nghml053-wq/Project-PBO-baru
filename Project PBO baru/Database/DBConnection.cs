using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Project_PBO_baru.Database
{
    internal class DBConnection
    {
        private string connectionString =
            "Host=localhost;" +
            "Port=5432;" +
            "Database=db_projectakhir;" +
            "Username=postgres;" +
            "Password=12345";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}