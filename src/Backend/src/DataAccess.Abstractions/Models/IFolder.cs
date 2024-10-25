using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface IFolder
    {
        int FolderId { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime LastModifiedDate { get; set; }
        int UserId { get; set; }
    }
}
