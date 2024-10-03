using DataAccess.sql.Repositories;
using Entities;

namespace BusinessLogic.core
{
    public class CRUDFile
    {
        #region Private Variable

        private FileRepository _file = new FileRepository();

        #endregion

        #region Index method
        public void GetAll(ref Entities.File file)
        {
            _file.GetAll(ref file);
        }

        #endregion

        #region CRUD Method

        public void GetById(ref Entities.File file)
        {
            _file.GetById(ref file);
        }

        public void Create(ref Entities.File file)
        {
            _file.Create(ref file);
        }

        public void Update(ref Entities.File file)
        {
            _file.Update(ref file);
        }

        public void Delete(ref Entities.File file)
        {
            _file.Delete(ref file);
        }

        #endregion
    }
}
