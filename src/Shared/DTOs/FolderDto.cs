
namespace DTOs
{
    public class FolderDto
    {
        #region Private Variable

        private int _folderId;
        private string _folderName;
        private DateTime _CreatedAt;
        private DateTime _LastModifiedAt;
        private int _userId;
        private List<TagDto> _tags;

        #endregion

        #region Public Variable
        public int FolderId { get => _folderId; set => _folderId = value; }
        public string FolderName { get => _folderName; set => _folderName = value; }
        public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; }
        public DateTime LastModifiedAt { get => _LastModifiedAt; set => _LastModifiedAt = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public List<TagDto> Tags { get => _tags; set => _tags = value; }

        #endregion

        #region Constructors
        public FolderDto()
        {

        }

        public FolderDto(int folderId, DateTime createdAt, DateTime lastModifiedAt, string folderName, int userId, List<TagDto> tags = null)
        {
            _folderId = folderId;
            _CreatedAt = createdAt;
            _LastModifiedAt = lastModifiedAt;
            _folderName = folderName;
            _userId = userId;
            _tags = tags;
        }

        #endregion
    }
}
