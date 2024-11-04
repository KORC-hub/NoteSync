using DTOs;

namespace Presentation.web.Models.ViewModels
{
    public class FolderViewModel
    {
        public string? FolderName { get; set; }

        public string? Taglist { get; set; }

        public List<FolderDto>? Folders { get; set; }
        public List<TagDto>? Tags { get; set; }
        public string[]? Filters { get; set; }

        public FolderViewModel()
        {
        }

        public FolderViewModel(List<FolderDto>? folders, List<TagDto>? tags)
        {
            Folders = folders;
            Tags = tags;
        }

    }
}
