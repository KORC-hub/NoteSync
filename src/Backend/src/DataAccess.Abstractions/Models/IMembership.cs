using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface IMembership
    {
        byte MembershipId { get; set; }
        string MembershipName { get; set; }
        decimal Price { get; set; }
    }
}
