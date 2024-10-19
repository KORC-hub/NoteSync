using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface IUser
    {
        int UserId { get; set; }
        string Nickname { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreatedAt { get; set; }
        string? ProfilePictureUrl { get; set; }
        byte MembershipId { get; set; }
    }
}
