using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Models
{
    public interface IPage
    {
        int PageId { get; set; }
        string Title { get; set; }
        string? Content { get; set; }
        int FolderId { get; set; }
    }
}
