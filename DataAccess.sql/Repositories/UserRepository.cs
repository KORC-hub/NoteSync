using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.sql;
using Entities;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace DataAccess.SQLServer.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Execute Method

        /// <summary>
        /// Executes the query and processes the results for the User object.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> that will be populated with the data obtained from the query.</param>
        /// <remarks>
        /// This method handles both scalar queries and datasets.If the query has an error, the error message will be 
        /// assigned to the <see cref ="User"/> object. In case the result is a dataset and contains a single record, 
        /// the user fields will be updated with the values obtained.
        /// </remarks>
        private void ProcessUserQueryResult(ref User user)
        {
            _query.Execute();
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    user.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    user.DataSetResult = _query.DataSetResult.Tables[0];
                    if (user.DataSetResult.Rows.Count == 1)
                    {
                        DataRow item = user.DataSetResult.Rows[0];
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
            else
            {
                user.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region Index Method

        /// <summary>
        /// Gets all the users from the database and loads them into the provided instance.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> where the results of the query will be stored in the DataSetResult attribute</param>
        public void GetAll(ref User user)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Index]";
            _query.Scalar = false;

            ProcessUserQueryResult(ref user);
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Gets a user from the database based on its ID and loads it into the provided instance.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> containing the ID of the user to search for. </param>
        /// <remarks>
        /// This method executes the stored procedure to read a user and, if one is found, its data 
        /// will be assigned to the object's properties <see cref="User"/>.
        /// </remarks>
        public void GetById(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Read]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", user.UserId);

            ProcessUserQueryResult(ref user);

        }

        /// <summary>
        /// Creates a new user in the database using the data provided in the user instance.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> containing the new user's data.</param>
        /// <remarks>
        /// This method executes the stored procedure to create a user and, if successfully created, 
        /// the ID of the new user will be mapped to <see cref="User.ScalarValue"/>.
        /// </remarks>
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

            ProcessUserQueryResult(ref user);
        }

        /// <summary>
        /// Updates the data of an existing user in the database using the instance provided.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> which contains the new user data.</param>
        /// <remarks>
        /// This method executes the stored procedure to update a user and, if the operation is successful, 
        /// the new values will be assigned to the object's properties <see cref="User"/>.
        /// </remarks>
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

            ProcessUserQueryResult(ref user);

        }

        /// <summary>
        /// Removes a user from the database using the ID provided in the instance.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> containing the ID of the user to be deleted.</param>
        /// <remarks>
        /// This method executes the stored procedure to delete a user. If the operation is successful, 
        /// the user will be removed from the database, the ID of the delete user will be 
        /// mapped to <see cref="User.ScalarValue"/>
        /// </remarks>
        public void Delete(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Delete]",
                Scalar = true

            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", user.UserId);

            ProcessUserQueryResult(ref user);

        }

        #endregion

        #region Find methods

        /// <summary>
        /// Gets a user from the database using the email provided and loads it into the instance.
        /// </summary>
        /// <param name="user">Reference to an object <see cref="User"/> containing the email address of the user to search for.</param>
        /// <returns>
        /// Returns <c>true</c> if an error occurred during the query, otherwise it returns <c>false</c>.
        /// </returns>
        public bool VerifyUserByEmail(string email, string password)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_By_Email]",
                Scalar = false

            };

            User user = new User
            {
                Email = email,
                Password = password
            };

            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);

            ProcessUserQueryResult(ref user);

            if (user.UserId != 0) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Authenticates a user using the email and password provided.
        /// </summary>
        /// <param name="entity">Reference to an object <see cref="User"/> containing the user's e-mail address and password.</param>
        /// <remarks>
        /// This method executes the stored procedure to authenticate the user. If the authentication is successful, 
        /// the user data will be loaded into the provided instance.
        /// </remarks>
        public bool AuthenticateUser(ref User user)
        {
            _query = new QueryExecuter
            {
                TableName = "[User]",
                StoredProcedureName = "[SP_User_Authenticate]",
                Scalar = false

            };

            _query.DataTableParameters.Rows.Add(@"@Email", "16", user.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", user.Password);

            ProcessUserQueryResult(ref user);

            if (user.UserId != 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
