using System.Data;

namespace DataAccess.sql
{
    internal static class ConvertParameters
    {
        /// <summary>
        /// Converts a string representing a data type to its equivalent in <see cref="SqlDbType"/>.
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns>The corresponding value of <see cref="SqlDbType"/> based on the string provided. If the string does not match any expected value, the default value of <see cref="SqlDbType"/> is returned.</returns>
        public static SqlDbType ToSQLDatatype(string? DataType) 
        {
            SqlDbType SQLDatatype = new SqlDbType();

            switch (DataType)
            {
                case "1":
                    SQLDatatype = SqlDbType.Bit;
                    break;
                case "2":
                    SQLDatatype = SqlDbType.TinyInt;
                    break;
                case "3":
                    SQLDatatype = SqlDbType.SmallInt;
                    break;
                case "4":
                    SQLDatatype = SqlDbType.Int;
                    break;
                case "5":
                    SQLDatatype = SqlDbType.BigInt;
                    break;
                case "6":
                    SQLDatatype = SqlDbType.Decimal;
                    break;
                case "7":
                    SQLDatatype = SqlDbType.SmallMoney;
                    break;
                case "8":
                    SQLDatatype = SqlDbType.Money;
                    break;
                case "9":
                    SQLDatatype = SqlDbType.Float;
                    break;
                case "10":
                    SQLDatatype = SqlDbType.Real;
                    break;
                case "11":
                    SQLDatatype = SqlDbType.Date;
                    break;
                case "12":
                    SQLDatatype = SqlDbType.Time;
                    break;
                case "13":
                    SQLDatatype = SqlDbType.SmallDateTime;
                    break;
                case "14":
                    SQLDatatype = SqlDbType.Char;
                    break;
                case "15":
                    SQLDatatype = SqlDbType.VarChar;
                    break;
                case "16":
                    SQLDatatype = SqlDbType.NVarChar;
                    break;
                default:
                    break;
            }

            return SQLDatatype;

        }

    }
}
