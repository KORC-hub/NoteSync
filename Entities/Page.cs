using System.Data;

namespace Entities
{
    public class Page
    {
        #region Private Variable

        private int _pageId;
        private string _content;
        private int _fileId;
        private string _title;
        private string _errorMessage, _scalarValue;
        private DataTable _dataSetResultado;

        #endregion

        #region Public Variable
        public int PageId { get => _pageId; set => _pageId = value; }
        public string Content { get => _content; set => _content = value; }
        public int FileId { get => _fileId; set => _fileId = value; }
        public string Title {

            get => _title;

            set
            {
                _title = value;
                if (value.Length > 45)
                {
                    throw new ArgumentException("Title cannot exceed 45 characters.");
                }
                
            }
        }
        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public string ScalarValue { get => _scalarValue; set => _scalarValue = value; }
        public DataTable DataSetResultado { get => _dataSetResultado; set => _dataSetResultado = value; }

        #endregion

        #region Constructors
        public Page()
        {

        }
        public Page(int pageId, string content, int fileId, string title)
        {
            _pageId = pageId;
            _content = content;
            _fileId = fileId;
            _title = title;
        }
        #endregion
    }
}
