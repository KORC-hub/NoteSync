using DataAccess.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.SqlServer.Models;

public partial class Tag : ITag
{
    public int TagId { get; set; }

    public int UserId { get; set; }

    public string TagContent { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<FolderTag> FolderTags { get; set; } = new List<FolderTag>();

    public virtual User User { get; set; } = null!;
}
