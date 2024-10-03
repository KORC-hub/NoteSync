using DataAccess.Abstractions.Repositories.Specific;
using Entities;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.sql.Repositories
{
    public class FileTagRepository : IFileTagRepository<FileTag>
    {
        #region Private Variable

        private QueryExecuter _query = null;

        #endregion

        #region Execute Method

        /// <summary>
        /// Executes the query and processes the results for the File object.
        /// </summary>
        /// <param name="filetag">Reference to an object <see cref="FileTag"/> that will be populated with the data obtained from the query.</param>
        /// <remarks>
        /// This method handles both scalar queries and datasets.If the query has an error, the error message will be 
        /// assigned to the <see cref ="FileTag"/> object. In case the result is a dataset and contains a single record, 
        /// the user fields will be updated with the values obtained.
        /// </remarks>
        private void ProcessFileTagQueryResult(ref FileTag filetag)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Index Method

        public IEnumerable<FileTag> GetAll(ref IEnumerable<FileTag> filetag)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CRUD Methods

        public void Create(ref FileTag filetag)
        {
            throw new NotImplementedException();
        }

        public void Delete(ref FileTag filetag)
        {
            throw new NotImplementedException();
        }

        public void GetById(ref FileTag filetag)
        {
            throw new NotImplementedException();
        }

        public void Update(ref FileTag filetag)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
