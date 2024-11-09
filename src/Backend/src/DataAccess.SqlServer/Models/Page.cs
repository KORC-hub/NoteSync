using DataAccess.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.SqlServer.Models;

public partial class Page : IPage
{
    public int PageId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
