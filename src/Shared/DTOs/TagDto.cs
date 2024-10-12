
namespace DTOs
{
    public class TagDto
    {
        #region Private Variable

        private int _tagId;
        private int _userId;
        private string _tagContent;
        private string _color;

        #endregion

        #region Public Variable
        public int TagId { get => _tagId; set => _tagId = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public string TagContent 
        {

            get => _tagContent;

            set
            {
                _tagContent = value;
                if (value.Length > 10)
                {
                    throw new ArgumentException("Tag content cannot exceed 45 characters.");
                }

            }
        }
        public string Color
        {

            get => _color;

            set
            {
                _color = value;
                if (value.Length > 7)
                {
                    throw new ArgumentException("Color must have hexadecimal format");
                }

            }
        }

        #endregion

        #region Constructors
        public TagDto() { }

        public TagDto(int tagId, int userId, string tagContent, string color)
        {
            _tagId = tagId;
            _userId = userId;
            _tagContent = tagContent;
            _color = color;
        }
        #endregion
    }
}
