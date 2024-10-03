using DataAccess.Abstractions.Repositories.Specific;
using Entities;
using System.Data;

namespace DataAccess.sql.Repositories
{
    public class FileRepository : IFileRepository<Entities.File>
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Execute Method

        /// <summary>
        /// Executes the query and processes the results for the File object.
        /// </summary>
        /// <param name="file">Reference to an object <see cref="File"/> that will be populated with the data obtained from the query.</param>
        /// <remarks>
        /// This method handles both scalar queries and datasets.If the query has an error, the error message will be 
        /// assigned to the <see cref ="File"/> object. In case the result is a dataset and contains a single record, 
        /// the user fields will be updated with the values obtained.
        /// </remarks>
        private void ProcessFileQueryResult(ref Entities.File file)
        {
            _query.Execute();
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    file.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    file.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (file.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in file.DataSetResultado.Rows)
                        {
                            file.FileId = Convert.ToInt32(item[0]);
                            file.CreatedAt = Convert.ToDateTime(item[1]);
                            file.LastModifiedAt = Convert.ToDateTime(item[2]);
                            file.UserId = Convert.ToInt32(item[3]);
                        }
                    }
                }
            }
            else
            {
                file.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region Index Method
        public IEnumerable<Entities.File> GetAll(ref IEnumerable<Entities.File> files)
        {
            throw new NotImplementedException();
        }

        public void GetAll(ref Entities.File file)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CRUD Methods

        public void GetById(ref Entities.File file)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Read]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", file.FileId);
            ProcessFileQueryResult(ref file);
        }

        public void Create(ref Entities.File File)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@UserId", "4", File.UserId);
            ProcessFileQueryResult(ref File);

        }

        public void Update(ref Entities.File file)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Update]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", file.FileId);

            ProcessFileQueryResult(ref file);
        }

        public void Delete(ref Entities.File file)
        {
            _query = new QueryExecuter
            {
                TableName = "[File]",
                StoredProcedureName = "[SP_File_Delete]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", file.FileId);
            ProcessFileQueryResult(ref file);
        }

        
        #endregion

    }
}
