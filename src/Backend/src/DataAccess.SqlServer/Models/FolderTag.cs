﻿using System;
using System.Collections.Generic;

namespace DataAccess.SqlServer.Models;

public partial class FolderTag
{
    public int FolderId { get; set; }

    public int TagId { get; set; }

    public virtual Folder Folder { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
