using System.Data;

namespace Entities
{
    public class User
    {
        #region Private Vriable

        private uint _userId;
        private string _nickname;
        private string _email;
        private string _password;
        private DateTime? _createdAt;
        private string? _profilePictureURL;
        private byte _membershipId;

        private string _errorMessage, _scalarValue;
        private DataTable _dataSetResultado;

        #endregion

        #region Public Variable
        public uint UserId { get => _userId; set => _userId = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime? CreatedAt { get => _createdAt; set => _createdAt = value; }
        public string? ProfilePictureURL { get => _profilePictureURL; set => _profilePictureURL = value; }
        public byte MembershipId { get => _membershipId; set => _membershipId = value; }


        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public string ScalarValue { get => _scalarValue; set => _scalarValue = value; }
        public DataTable DataSetResult { get => _dataSetResultado; set => _dataSetResultado = value; }

        #endregion

        #region Constructors
        public User() { }

        public User(uint userId, string nickname, string email, string password, string? profilePictureURL, byte membershipId, DateTime? createdAt)
        {
            _userId = userId;
            _nickname = nickname;
            _email = email;
            _password = password;
            _profilePictureURL = profilePictureURL;
            _membershipId = membershipId;
            _createdAt = createdAt;
        }
        #endregion


    }
}
