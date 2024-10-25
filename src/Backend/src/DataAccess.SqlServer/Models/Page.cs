using DataAccess.Abstractions.Models;
namespace DataAccess.SqlServer.Models;

public partial class Page : IPage
{
    public int PageId { get; set; }

    public string? Content { get; set; }

    public int FolderId { get; set; }

    public string Title { get; set; } = null!;

    public virtual Folder Folder { get; set; } = null!;
}
