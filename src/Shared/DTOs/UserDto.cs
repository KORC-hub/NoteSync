
namespace DTOs
{
    public class UserDto
    {
        #region Private Vriable

        private string _userId;
        private string _nickname;
        private string _email;
        private string _password;
        private string? _profilePictureURL;
        private string _membership;

        #endregion

        #region Public Variable
        public string UserId { get => _userId; set => _userId = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string? ProfilePictureURL { get => _profilePictureURL; set => _profilePictureURL = value; }
        public string Membership { get => _membership; set => _membership = value; }

        #endregion

        #region Constructors
        public UserDto() { }

        public UserDto(string userId, string nickname, string email, string password, string? profilePictureURL, string membership)
        {
            _userId = userId;
            _nickname = nickname;
            _email = email;
            _password = password;
            _profilePictureURL = profilePictureURL;
            _membership = membership;
        }
        #endregion

    }
}
