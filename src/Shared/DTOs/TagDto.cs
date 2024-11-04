
namespace DTOs
{
    public class TagDto
    {
        #region Private Variable
        private string _type;
        private string _tagId;
        private int _userId;
        private string _tagContent;
        private string _color;

        #endregion

        #region Public Variable
        public string TagId { get; set; }
        public int UserId { get => _userId; set => _userId = value; }
        public string TagContent 
        {

            get => _tagContent;

            set
            {
                _tagContent = value;
                if (value.Length > 20)
                {
                    throw new ArgumentException("Tag content cannot exceed 20 characters.");
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

        public string Type { get => _type; set => _type = value; }

        #endregion

        #region Constructors
        public TagDto() { }

        public TagDto(string tagId, int userId, string tagContent, string color, string type)
        {
            _tagId = tagId;
            _userId = userId;
            _tagContent = tagContent;
            _color = color;
            _type = type;
        }
        #endregion
    }
}
