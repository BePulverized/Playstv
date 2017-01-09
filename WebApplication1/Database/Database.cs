using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Plays.tv.Database
{
    public class Database
    {
        // De bestandsnaam voor de database
        
        private static readonly string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi304796;Persist Security Info=True;User ID=dbi304796;Password=Underground2";
        /// <summary>
        /// Creates a new database connection and directly opens it. The caller
        /// is resposible for properly closing the connection.
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
        /// <summary>
        /// Create a new database if it doesn't exist, and fill it with some
        /// dummy data.
        /// </summary>
        public static void Initialize()
        {
            
            
        }
    }
}
