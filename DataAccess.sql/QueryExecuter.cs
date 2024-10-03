using System.Data.SqlClient;
using System.Data;

namespace DataAccess.sql
{
    internal class QueryExecuter
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

        private void AddParameter()
        {
            if (this.DataTableParameters != null)
            {
                foreach (DataRow item in this.DataTableParameters.Rows)
                {

                    Dictionary<string, string> Parameters = new Dictionary<string, string>
                    {
                        { "Name", item[0].ToString() },
                        { "DataType", item[1].ToString() },
                        { "Value", item[2].ToString() }
                    };

                    bool ItsParameterValueNull = Parameters["Value"].Equals(string.Empty);
                    SqlDbType ParameterSQLType = ConvertParameters.ToSQLDatatype(Parameters["DataType"]);

                    if (this.Scalar)
                    {
                        //  ternary(?)                                                                      condition       ?  consequent  : alternative
                        this.SqlCommand.Parameters.Add(Parameters["Name"], ParameterSQLType).Value = ItsParameterValueNull ? DBNull.Value : Parameters["Value"];
                    }
                    else
                    {
                        this.SqlDataAdapter.SelectCommand.Parameters.Add(Parameters["Name"], ParameterSQLType).Value = ItsParameterValueNull ? DBNull.Value : Parameters["Value"];
                    }
                }
            }
        }

        private void DataAdapterExecuter()
        {
            try
            {
                _Connection.StartDatabaseConnection(this.DatabaseName);
                this.SqlDataAdapter = new SqlDataAdapter(this.StoredProcedureName, _Connection.SqlConnection);
                this.SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AddParameter();
                this.DataSetResult = new DataSet();
                this.SqlDataAdapter.Fill(this.DataSetResult, this.DatabaseName);

            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                if (this._Connection.SqlConnection.State == ConnectionState.Open)
                {
                    this._Connection.CheckConnectionStatus();
                }
            }

        }

        private void CommandExecuter()
        {
            try
            {
                _Connection.StartDatabaseConnection(this.DatabaseName);
                this.SqlCommand = new SqlCommand(this.StoredProcedureName, _Connection.SqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                AddParameter();
                if (this.Scalar)
                {
                    this.ScalarValue = this.SqlCommand.ExecuteScalar().ToString().Trim(); // is used when the SQL query returns only a single value 
                }
                else
                {
                    this.SqlCommand.ExecuteNonQuery().ToString().Trim(); // executes a SQL statement that does not return any result set.
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                if (this._Connection.SqlConnection.State == ConnectionState.Open)
                {
                    _Connection.CheckConnectionStatus();
                }
            }
        }

        #endregion

        #region Public Methods

        public void Execute()
        {
            if (this.Scalar)
            {
                CommandExecuter();
            }
            else
            {
                DataAdapterExecuter();
            }
        }

        #endregion


    }
}