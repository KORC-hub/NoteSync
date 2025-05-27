namespace API.core.Models
{
    public class Tag
    {
        private string _tagContent;
        private string _color;
        private string _type;

        public string TagContent { get => _tagContent; set => _tagContent = value; }
        public string Color { get => _color; set => _color = value; }
        public string Type { get => _type; }

        public Tag(string tagContent, string color, string type)
        {
            _tagContent = tagContent;
            _color = color;
            _type = type;
        }
    }
}
