using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface IFolderTag
    {
        int Id { get; set; }
        int FolderId { get; set; }
        int TagId { get; set; }
    }
}
