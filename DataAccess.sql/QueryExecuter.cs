using System.Data.SqlClient;
using System.Data;

namespace DataAccess.sql
{
    public class QueryExecuter
    {
        #region Private Variable
        // Information needed to make queries

        private ConnectionManager _Connection = new ConnectionManager(); // Contains the Connection string and methods for initiating, verifying and starting the connection.
        private SqlDataAdapter _SqlDataAdapter; // Select Queries
        private SqlCommand _SqlCommand;
        private DataTable _DataTableParameters;
        private DataSet _DataSetResult;
        private string _TableName, _StoredProcedureName, _ErrorMessage, _ScalarValue, _DatabaseName; // Information for query
        private bool _Scalar;

        #endregion

        #region Public Variable
        internal ConnectionManager Connection { get => _Connection; set => _Connection = value; }

        /// <summary>
        /// Used to select queries
        /// </summary>
        public SqlDataAdapter SqlDataAdapter { get => _SqlDataAdapter; set => _SqlDataAdapter = value; }

        /// <summary>
        /// Used for update type queries (Add, Update, Delete).
        /// </summary>
        public SqlCommand SqlCommand { get => _SqlCommand; set => _SqlCommand = value; }

        /// <summary>
        /// Table with the parameters used in the stored procedure
        /// </summary>
        public DataTable DataTableParameters { get => _DataTableParameters; set => _DataTableParameters = value; }


        public DataSet DataSetResult { get => _DataSetResult; set => _DataSetResult = value; }
        public string TableName { get => _TableName; set => _TableName = value; }
        public string StoredProcedureName { get => _StoredProcedureName; set => _StoredProcedureName = value; }
        public string ErrorMessage { get => _ErrorMessage; set => _ErrorMessage = value; }
        public string ScalarValue { get => _ScalarValue; set => _ScalarValue = value; }
        public string DatabaseName { get => _DatabaseName; set => _DatabaseName = value; }

        /// <summary>
        /// Defines the type of query: true -> update, false -> select
        /// </summary>
        public bool Scalar { get => _Scalar; set => _Scalar = value; }

        #endregion

        #region Constructor

        public QueryExecuter()
        {
            DataTableParameters = new DataTable();
            DataTableParameters.Columns.Add("Name");
            DataTableParameters.Columns.Add("DataType");
            DataTableParameters.Columns.Add("Value");
            DatabaseName = "NoteSyncDB";
        }

        #endregion

        #region Private Methods

        private void AddParameter(ref QueryExecuter Query) 
        {
            if (Query.DataTableParameters != null)
            {
                foreach (DataRow item in Query.DataTableParameters.Rows)
                {

                    Dictionary<string, string> Parameters = new Dictionary<string, string>
                    {
                        { "Name", item[0].ToString() },
                        { "DataType", item[1].ToString() },
                        { "Value", item[2].ToString() }
                    };

                    bool ItsParameterValueNull = Parameters["Value"].Equals(string.Empty);
                    SqlDbType ParameterSQLType = ConvertParameters.ToSQLDatatype(Parameters["DataType"]);

                    if (Query.Scalar)
                    {
                        //  ternary(?)                                                                      condition       ?  consequent  : alternative
                        Query.SqlCommand.Parameters.Add(Parameters["Name"], ParameterSQLType).Value = ItsParameterValueNull ? DBNull.Value : Parameters["Value"];
                    }
                    else
                    {
                        Query.SqlDataAdapter.SelectCommand.Parameters.Add(Parameters["Name"], ParameterSQLType).Value = ItsParameterValueNull ? DBNull.Value : Parameters["Value"];
                    }
                }
            }
        }

        private void DataAdapterExecuter(ref QueryExecuter Query)
        {
            try
            {
                Connection.StartDatabaseConnection(Query.DatabaseName);
                Query.SqlDataAdapter = new SqlDataAdapter(Query.StoredProcedureName, Connection.SqlConnection);
                Query.SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AddParameter(ref Query);
                Query.DataSetResult = new DataSet();
                Query.SqlDataAdapter.Fill(Query.DataSetResult, Query.DatabaseName);

            }
            catch (Exception ex)
            {
                Query.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                if (Query.Connection.SqlConnection.State == ConnectionState.Open)
                {
                    Query.Connection.CheckConnectionStatus();
                }
            }

        }

        private void CommandExecuter(ref QueryExecuter Query)
        {
            try
            {
                Connection.StartDatabaseConnection(Query.DatabaseName);
                Query.SqlCommand = new SqlCommand(Query.StoredProcedureName, Connection.SqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                AddParameter(ref Query);
                if (Query.Scalar)
                {
                    Query.ScalarValue = Query.SqlCommand.ExecuteScalar().ToString().Trim(); // is used when the SQL query returns only a single value 
                }
                else
                {
                    Query.SqlCommand.ExecuteNonQuery().ToString().Trim(); // executes a SQL statement that does not return any result set.
                }
            }
            catch (Exception ex)
            {
                Query.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                if (Query._Connection.SqlConnection.State == ConnectionState.Open)
                {
                    Connection.CheckConnectionStatus();
                }
            }
        }

        #endregion

        #region Public Methods

        public void Execute(ref QueryExecuter Query)
        {
            if (Query.Scalar)
            {
                CommandExecuter(ref Query);
            }
            else
            {
                DataAdapterExecuter(ref Query);
            }
        }

        #endregion

    }
}
