using DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.core.Models
{
    public class Folder
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FolderName { get; set; }

        public List<Tag>? Tags { get; set; }

        #region Constructors

        public Folder(int userId, string folderName, List<Tag>? tags)
        {
            UserId = userId;
            FolderName = folderName;
            Tags = tags ?? new List<Tag>();
        }

        #endregion
    }
}
