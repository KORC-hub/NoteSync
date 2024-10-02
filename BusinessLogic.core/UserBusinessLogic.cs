using DataAccess.sql;
using Entities;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BusinessLogic.core
{
    public class UserBusinessLogic
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Index Method

        public void Index(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Index]",
                Scalar = false
            };

            _query.Execute(ref _query);
            user.DataSetResult = _query.DataSetResult.Tables[0];
        }

        #endregion

        #region Execute Method

        private void Execute(ref User user)
        {
            _query.Execute(ref _query);
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    user.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    user.DataSetResult = _query.DataSetResult.Tables[0];
                    if (user.DataSetResult.Rows.Count > 0)
                    {
                        foreach (DataRow item in user.DataSetResult.Rows)
                        {
                            user.UserId = Convert.ToUInt32(item[0]);
                            user.Nickname = item[1].ToString();
                            user.Email = item[2].ToString();
                            user.Password = item[3].ToString();
                            user.CreatedAt = Convert.ToDateTime(item[4]);
                            user.ProfilePictureURL = item[5].ToString();
                            user.Membership = item[6].ToString();
                        }
                    }
                }
            }
            else
            {
                user.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region CRUD Methods
        public void Create(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@UserNickname", "16", user.Nickname);
            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", user.Password);

            Execute(ref user);
        }

        public void Read(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Read]",
                Scalar = false

            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", user.UserId);

            Execute(ref user);

        }

        public void Update(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Update]",
                Scalar = true

            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", user.UserId);
            _query.DataTableParameters.Rows.Add(@"@UserNickname", "16", user.Nickname);
            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", user.Password);

            Execute(ref user);

        }

        public void Delete(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Delete]",
                Scalar = true

            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", user.UserId);

            Execute(ref user);

        }

        #endregion

        #region Find methods

        public void UserByEmail(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_By_Email]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", user.Password);

            Execute(ref user);
        }

        #endregion


        public bool Login(ref User user)
        {
            string errorMessage = string.Empty;
            uint userId = 0;

            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Login]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", user.Password);

            Execute(ref user);

            if (!string.IsNullOrEmpty(_query.ErrorMessage))
            {
                errorMessage = _query.ErrorMessage;

                return false;
            }

            if (!string.IsNullOrEmpty(_query.ScalarValue))
            {
                userId = uint.Parse(_query.ScalarValue);
                user.UserId = userId; 
                return true;
            }

            return false;
        }
    }
}
