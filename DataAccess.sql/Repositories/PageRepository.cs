using Entities;
using DataAccess.Abstractions.Repositories.Specific;
using System.Data;

namespace DataAccess.sql.Repositories
{
    public class PageRepository : IPageRepository<Page>
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Execute Method

        /// <summary>
        /// Executes the query and processes the results for the File object.
        /// </summary>
        /// <param name="page">Reference to an object <see cref="Page"/> that will be populated with the data obtained from the query.</param>
        /// <remarks>
        /// This method handles both scalar queries and datasets.If the query has an error, the error message will be 
        /// assigned to the <see cref ="Page"/> object. In case the result is a dataset and contains a single record, 
        /// the user fields will be updated with the values obtained.
        /// </remarks>
        private void ProcessPageQueryResult(ref Page page)
        {
            _query.Execute();
            if (_query.ErrorMessage == null)
            {
                if (_query.Scalar)
                {
                    page.ScalarValue = _query.ScalarValue;
                }
                else
                {
                    page.DataSetResultado = _query.DataSetResult.Tables[0];
                    if (page.DataSetResultado.Rows.Count > 0)
                    {
                        foreach (DataRow item in page.DataSetResultado.Rows)
                        {
                            page.PageId = Convert.ToInt32(item[0]);
                            page.Content = Convert.ToString(item[1]);
                            page.FileId = Convert.ToInt32(item[2]);
                            page.Title = Convert.ToString(item[3]);
                        }
                    }
                }
            }
            else
            {
                page.ErrorMessage = _query.ErrorMessage;
            }
        }

        #endregion

        #region Index Method
        public IEnumerable<Page> GetAll(ref IEnumerable<Page> entities)
        {
            throw new NotImplementedException();
        }
        public void GetAll(ref Page page)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD Methods

        public void GetById(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Read]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);

            ProcessPageQueryResult(ref page);
        }

        public void Create(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Create]",
                Scalar = true
            };

            _query.DataTableParameters.Rows.Add(@"@FileId", "4", page.FileId);
            _query.DataTableParameters.Rows.Add(@"@Content", "16", page.Content);

            ProcessPageQueryResult(ref page);
        }

        public void Update(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Update]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);
            _query.DataTableParameters.Rows.Add(@"@Content", "16", page.Content);

            ProcessPageQueryResult(ref page);
        }

        public void Delete(ref Page page)
        {
            _query = new QueryExecuter
            {
                TableName = "[Page]",
                StoredProcedureName = "[SP_Page_Delete]",
                Scalar = false
            };

            _query.DataTableParameters.Rows.Add(@"@PageId", "4", page.PageId);

            ProcessPageQueryResult(ref page);
        }

        #endregion

    }
}
