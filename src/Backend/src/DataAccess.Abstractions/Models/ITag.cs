using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface ITag
    {
        int TagId { get; set; }
        int UserId { get; set; }
        string TagContent { get; set; }
        string Color { get; set; }
    }
}
