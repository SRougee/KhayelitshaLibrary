using Microsoft.Data.SqlClient;
using System.Configuration;

namespace KhayelitshaLibrary
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString =
            ConfigurationManager
                .ConnectionStrings["LibraryConnection"]
                .ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}