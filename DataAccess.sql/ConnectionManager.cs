using System.Data;
using System.Data.SqlClient;

namespace DataAccess.sql
{
    internal class ConnectionManager
    {

        private SqlConnection _SqlConnection;
        public SqlConnection SqlConnection { get => _SqlConnection; set => _SqlConnection = value; }

        #region Private Methods

        /// <summary>
        /// Creates a connection to the database specified by the database name.
        /// </summary>
        /// <param name="DatabaseName">The name of the database you want to connect to. Currently, only "NoteSyncDB" is supported.</param>
        private void CreateConnection(string DatabaseName)
        {
            switch (DatabaseName)
            {
                case "NoteSyncDB":
                    SqlConnection = new SqlConnection("Data Source=Jhonatan\\SQLEXPRESS;Initial Catalog=NoteSyncDB;Integrated Security=True;TrustServerCertificate=True");
                    break;
            }

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks the status of the SQL connection. If the connection is closed, it opens it. 
        /// If the connection is already open, it closes it and disposes of the unmanaged resources.
        /// </summary>
        internal void CheckConnectionStatus()
        {
            if (SqlConnection.State == ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
            else
            {
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
        }

        /// <summary>
        /// Initiates the connection to the specified database. Creates the connection and verifies it.
        /// </summary>
        /// <param name="DatabaseName">The name of the database to connect to.</param>
        internal void StartDatabaseConnection(string DatabaseName)
        {
            CreateConnection(DatabaseName);
            CheckConnectionStatus();
        }

        #endregion

    }
}