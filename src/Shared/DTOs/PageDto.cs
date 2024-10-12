
namespace DTOs
{
    public class PageDto
    {
        #region Private Variable

        private int _pageId;
        private string _content;
        private int _folderId;
        private string _title;

        #endregion

        #region Public Variable
        public int PageId { get => _pageId; set => _pageId = value; }
        public string Content { get => _content; set => _content = value; }
        public int FolderId { get => _folderId; set => _folderId = value; }
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

        #endregion

        #region Constructors
        public PageDto()
        {

        }
        public PageDto(int pageId, string content, int folderId, string title)
        {
            _pageId = pageId;
            _content = content;
            _folderId = folderId;
            _title = title;
        }
        #endregion
    }
}
