using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FileTagDto
    {
        #region Private Variable

        private int _fileId;
        private int _tagId;
        private string _errorMessage, _scalarValue;
        private DataTable _dataSetResultado;

        #endregion

        #region Public Variable
        public int FileId { get => _fileId; set => _fileId = value; }
        public int TagId { get => _tagId; set => _tagId = value; }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public string ScalarValue { get => _scalarValue; set => _scalarValue = value; }
        public DataTable DataSetResultado { get => _dataSetResultado; set => _dataSetResultado = value; }
        #endregion

        #region Constructors

        public FileTagDto()
        {

        }
        public FileTagDto(int fileId, int tagId)
        {
            _fileId = fileId;
            _tagId = tagId;
        }
        #endregion
    }
}
