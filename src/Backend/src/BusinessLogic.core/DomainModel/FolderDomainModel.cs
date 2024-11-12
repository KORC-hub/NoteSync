
namespace DomainModel
{
    public class FolderDomainModel
    {
        #region Private Variable

        private int _folderId;
        private string _folderName;
        private DateTime _CreatedAt;
        private DateTime _LastModifiedAt;
        private bool _isPinned;
        private int _userId;

        #endregion

        #region Public Variable

        public int FolderId { get => _folderId; set => _folderId = value; }
        public string FolderName { get => _folderName; set => _folderName = value; }
        public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; }
        public DateTime LastModifiedAt { get => _LastModifiedAt; set => _LastModifiedAt = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public bool IsPinned { get => _isPinned; set => _isPinned = value; }

        #endregion

        #region Constructors
        public FolderDomainModel()
        {

        }

        public FolderDomainModel(int folderId, DateTime createdAt, DateTime lastModifiedAt, int userId, string folderName, bool isPinned = false)
        {
            _folderId = folderId;
            _CreatedAt = createdAt;
            _LastModifiedAt = lastModifiedAt;
            _userId = userId;
            _folderName = folderName;
            _isPinned = isPinned;
        }

        #endregion
    }
}
