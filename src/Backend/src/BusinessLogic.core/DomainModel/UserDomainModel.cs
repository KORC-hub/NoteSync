
namespace DomainModel
{
    public class UserDomainModel
    {
        #region Private Vriable

        private uint _userId;
        private string _nickname;
        private string _email;
        private string _password;
        private DateTime? _createdAt;
        private string? _profilePictureURL;
        private string _membership;

        #endregion

        #region Public Variable
        public uint UserId { get => _userId; set => _userId = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string? ProfilePictureURL { get => _profilePictureURL; set => _profilePictureURL = value; }
        public string Membership { get => _membership; set => _membership = value; }

        #endregion

        #region Constructors
        public UserDomainModel() { }

        public UserDomainModel(uint userId, string nickname, string email, string password, string? profilePictureURL, string membership, DateTime? createdAt)
        {
            _userId = userId;
            _nickname = nickname;
            _email = email;
            _password = password;
            _profilePictureURL = profilePictureURL;
            _membership = membership;
            _createdAt = createdAt;
        }
        #endregion

    }
}
