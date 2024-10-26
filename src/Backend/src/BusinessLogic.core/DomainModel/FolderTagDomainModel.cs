
namespace DomainModel
{
    public class FolderTagDomainModel
    {
        #region Private Variable

        private int _folderTagId;
        private int _folderId;
        private int _tagId;

        #endregion

        #region Public Variable
        public int FolderTagId { get => _folderTagId; set => _folderTagId = value; }
        public int FolderId { get => _folderId; set => _folderId = value; }
        public int TagId { get => _tagId; set => _tagId = value; }
        #endregion

        #region Constructors

        public FolderTagDomainModel()
        {

        }
        public FolderTagDomainModel(int fileId, int tagId, int folderTagId = 0)
        {
            _folderTagId = folderTagId;
            _folderId = fileId;
            _tagId = tagId;
        }
        #endregion
    }
}
