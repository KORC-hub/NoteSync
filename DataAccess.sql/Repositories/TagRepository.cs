using Entities;
using DataAccess.Abstractions.Repositories.Specific;
using System.Data;

namespace DataAccess.sql.Repositories
{
    public class TagRepository : ITagRepository<Tag>
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Execute Method

        /// <summary>
        /// Executes the query and processes the results for the File object.
        /// </summary>
        /// <param name="tag">Reference to an object <see cref="Tag"/> that will be populated with the data obtained from the query.</param>
        /// <remarks>
        /// This method handles both scalar queries and datasets.If the query has an error, the error message will be 
        /// assigned to the <see cref ="Tag"/> object. In case the result is a dataset and contains a single record, 
        /// the user fields will be updated with the values obtained.
        /// </remarks>
        private void ProcessTagQueryResult(ref Tag tag)
        {
            _query.Execute();
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    tag.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    tag.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (tag.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in tag.DataSetResultado.Rows)
                        {
                            tag.TagId = Convert.ToInt32(item[0]);
                            tag.UserId = Convert.ToInt32(item[1]);
                            tag.TagContent = Convert.ToString(item[2]);
                            tag.Color = Convert.ToString(item[3]);
                        }
                    }
                }
            }
            else
            {
                tag.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region Index Method

        public IEnumerable<Tag> GetAll(ref IEnumerable<Tag> entities)
        {
            throw new NotImplementedException();
        }
        public void GetAll(ref Tag tag)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CRUD Method

        public void GetById(ref Tag tag)
        {
            _query = new QueryExecuter
            {
                TableName = "[FileTag]",
                StoredProcedureName = "[SP_Tag_Read]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@UserId", SqlDbType.Int, tag.UserId);

            ProcessTagQueryResult(ref tag);
        }

        public void Create(ref Tag tag)
        {
            _query = new QueryExecuter
            {
                TableName = "[Tag]",
                StoredProcedureName = "[SP_Tag_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@TagContent", "16", tag.TagContent);
            _query.DataTableParameters.Rows.Add(@"@UserId", "4", tag.UserId);
            _query.DataTableParameters.Rows.Add(@"@Color", "15", tag.Color);

            ProcessTagQueryResult(ref tag);
            tag.TagId = Convert.ToInt32(_query.ScalarValue);
        }

        public void Update(ref Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Delete(ref Tag tag)
        {
            _query = new QueryExecuter
            {
                TableName = "[Tag]",
                StoredProcedureName = "[SP_Tag_Delete]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@TagId", "4", tag.TagId);

            ProcessTagQueryResult(ref tag);
        }

        #endregion


    }
}
