
namespace DTOs
{
    public class FileTagDto
    {
        #region Private Variable

        private int _folderId;
        private int _tagId;

        #endregion

        #region Public Variable
        public int FolderId { get => _folderId; set => _folderId = value; }
        public int TagId { get => _tagId; set => _tagId = value; }

        #endregion

        #region Constructors

        public FileTagDto()
        {

        }
        public FileTagDto(int folderId, int tagId)
        {
            _folderId = folderId;
            _tagId = tagId;
        }
        #endregion
    }
}
