using DataAccess.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.SqlServer.Models;

public partial class FolderTag : IFolderTag
{
    public int FolderTagId { get; set; }

    public int FolderId { get; set; }

    public int TagId { get; set; }

    public virtual Folder Folder { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
