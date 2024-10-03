using System.Data;

namespace DataAccess.sql
{
    internal class ConvertParameters
    {

        private static Dictionary<string, SqlDbType> sqlDataTypeDictionary = new Dictionary<string, SqlDbType>()
        {
            { "1", SqlDbType.Bit },
            { "2", SqlDbType.TinyInt },
            { "3", SqlDbType.SmallInt },
            { "4", SqlDbType.Int },
            { "5", SqlDbType.BigInt },
            { "6", SqlDbType.Decimal },
            { "7", SqlDbType.SmallMoney },
            { "8", SqlDbType.Money },
            { "9", SqlDbType.Float },
            { "10", SqlDbType.Real },
            { "11", SqlDbType.Date },
            { "12", SqlDbType.Time },
            { "13", SqlDbType.SmallDateTime },
            { "14", SqlDbType.Char },
            { "15", SqlDbType.VarChar },
            { "16", SqlDbType.NVarChar },
            { "17", SqlDbType.DateTime },
            { "18", SqlDbType.DateTime2 }
        };


        /// <summary>
        /// Converts a string representing a data type to its equivalent in <see cref="SqlDbType"/>.
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns>The corresponding value of <see cref="SqlDbType"/> based on the string provided. If the string does not match any expected value, the default value of <see cref="SqlDbType"/> is returned.</returns>
        public static SqlDbType ToSQLDatatype(string DataType) 
        {
            SqlDbType SQLDatatype = new SqlDbType();

            if (sqlDataTypeDictionary.TryGetValue(DataType, out SQLDatatype))
            {
                return SQLDatatype;
            }
            else
            {
                throw new ArgumentException($"The value '{DataType}' is not a valid data type.", nameof(DataType));
            }
        }

    }
}
