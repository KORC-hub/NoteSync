
namespace DTOs
{
    public class FolderDto
    {
        #region Private Variable

        private int _folderId;
        private DateTime _CreatedAt;
        private DateTime _LastModifiedAt;

        #endregion

        #region Public Variable
        public int FolderId { get => _folderId; set => _folderId = value; }
        public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; }
        public DateTime LastModifiedAt { get => _LastModifiedAt; set => _LastModifiedAt = value; }

        #endregion

        #region Constructors
        public FolderDto()
        {

        }

        public FolderDto(int folderId, DateTime createdAt, DateTime lastModifiedAt)
        {
            _folderId = folderId;
            _CreatedAt = createdAt;
            _LastModifiedAt = lastModifiedAt;
        }

        #endregion
    }
}
