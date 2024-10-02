using DataAccess.Abstractions.Repositories.Specific;
using Entities;
using System.Data;

namespace DataAccess.SQLServer.Repositories
{
    internal class UserRepository : IUserRepository<User>
    {
        #region Private Variable

        private QueryExecuter _query;

        #endregion

        #region Constructors

        public UserRepository(QueryExecuter query)
        {
            _query = query;
        }

        public UserRepository()
        {
            _query = new QueryExecuter();
        }

        #endregion

        #region Index Method

        public void GetAll(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Index]";
            _query.Scalar = false;

            StoredProcedureExecute(ref entity);
        }

        #endregion

        #region Execute Method

        private void StoredProcedureExecute(ref User entity)
        {
            _query.Execute();
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    entity.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    entity.DataSetResult = _query.DataSetResult.Tables[0];
                    if (entity.DataSetResult.Rows.Count == 1)
                    {
                        DataRow item = entity.DataSetResult.Rows[0];
                        entity.UserId = Convert.ToUInt32(item[0]);
                        entity.Nickname = item[1].ToString();
                        entity.Email = item[2].ToString();
                        entity.Password = item[3].ToString();
                        entity.CreatedAt = Convert.ToDateTime(item[4]);
                        entity.ProfilePictureURL = item[5].ToString();
                        entity.Membership = item[6].ToString();
                    }
                }
            }
            else
            {
                entity.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region CRUD Methods
        public void Create(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Create]";
            _query.Scalar = true;

            _query.DataTableParameters.Rows.Add(@"@UserNickname", "16", entity.Nickname);
            _query.DataTableParameters.Rows.Add(@"@Email", "16", entity.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", entity.Password);

            StoredProcedureExecute(ref entity);
        }

        public void GetById(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Read]";
            _query.Scalar = false;

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", entity.UserId);

            StoredProcedureExecute(ref entity);

        }

        public void Update(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Update]";
            _query.Scalar = true;

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", entity.UserId);
            _query.DataTableParameters.Rows.Add(@"@UserNickname", "16", entity.Nickname);
            _query.DataTableParameters.Rows.Add(@"@Email", "16", entity.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", entity.Password);

            StoredProcedureExecute(ref entity);

        }

        public void Delete(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_Delete]";
            _query.Scalar = true;

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", entity.UserId);

            StoredProcedureExecute(ref entity);

        }

        #endregion

        #region Find methods

        public void GetByEmail(ref User entity)
        {
            _query.TableName = "[User]";
            _query.StoredProcedureName = "[SP_User_By_Email]";
            _query.Scalar = false;

            _query.DataTableParameters.Rows.Add(@"@Email", "16", entity.Email);
            _query.DataTableParameters.Rows.Add(@"@Password", "16", entity.Password);

            StoredProcedureExecute(ref entity);
        }

        #endregion
    }
}
