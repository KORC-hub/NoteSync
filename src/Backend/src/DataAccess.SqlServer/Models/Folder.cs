using DataAccess.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.SqlServer.Models;

public partial class Folder : IFolder
{
    public int FolderId { get; set; }

    public string FolderName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<FolderTag> FolderTags { get; set; } = new List<FolderTag>();

    public virtual ICollection<Page> Pages { get; set; } = new List<Page>();

    public virtual User User { get; set; } = null!;
}
