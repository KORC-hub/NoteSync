
namespace DTOs
{
    public class UserDto
    {
        #region Private Vriable

        private string _nickname;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string? _profilePictureURL;
        private string _membership;

        #endregion

        #region Public Variable
        public string Nickname { get => _nickname; set => _nickname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value; }
        public string? ProfilePictureURL { get => _profilePictureURL; set => _profilePictureURL = value; }
        public string Membership { get => _membership; set => _membership = value; }

        #endregion

        #region Constructors
        public UserDto() { }

        public UserDto(string nickname, string email, string password, string Confirmpassword, string? profilePictureURL, string membership)
        {
            _nickname = nickname;
            _email = email;
            _password = password;
            _confirmPassword = Confirmpassword;
            _profilePictureURL = profilePictureURL;
            _membership = membership;
        }
        #endregion

    }
}
