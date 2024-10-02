using System.Data;

namespace Entities
{
    public class Membership
    {
        #region Private Variable

        private byte _membershipId;
        private string _membershipName;
        private double _membershipPrice;

        private string _errorMessage, _scalarValue;
        private DataTable _dataSetResultado;

        #endregion

        #region Public Variable

        public byte MembershipId1 { get => _membershipId; set => _membershipId = value; }
        public string MembershipName1 { get => _membershipName; set => _membershipName = value; }
        public double MembershipPrice1 { get => _membershipPrice; set => _membershipPrice = value; }

        #endregion

        #region Constructor

        public Membership(byte MembershipId, string MembershipName, double MembershipPrice)
        {
            _membershipId = MembershipId;
            _membershipName = MembershipName;
            _membershipPrice = MembershipPrice;
        }

        #endregion

    }
}
