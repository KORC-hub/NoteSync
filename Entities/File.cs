using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class File
    {
        #region Private Variable

        private int _fileId;
        private DateTime _CreatedAt;
        private DateTime _LastModifiedAt;
        private int _userId;
        private string _errorMessage, _scalarValue;
        private DataTable _dataSetResultado;

        #endregion

        #region Public Variable
        public int FileId { get => _fileId; set => _fileId = value; }
        public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; }
        public DateTime LastModifiedAt { get => _LastModifiedAt; set => _LastModifiedAt = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public string ScalarValue { get => _scalarValue; set => _scalarValue = value; }
        public DataTable DataSetResultado { get => _dataSetResultado; set => _dataSetResultado = value; }
        #endregion

        #region Constructors
        public File()
        {

        }

        public File(int fileId, DateTime createdAt, DateTime lastModifiedAt, int userId)
        {
            _fileId = fileId;
            _CreatedAt = createdAt;
            _LastModifiedAt = lastModifiedAt;
            _userId = userId;
        }

        #endregion
    }
}
