using DataAccess.Abstractions.Models;
namespace DataAccess.SqlServer.Models;

public partial class Membership : IMembership
{
    public byte MembershipId { get; set; }

    public string MembershipName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
