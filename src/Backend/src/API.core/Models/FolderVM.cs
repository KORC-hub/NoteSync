using DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.core.Models
{
    public class FolderVM
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FolderName { get; set; }

        //public List<TagDto>? Tags { get; set; }

        #region Constructors

        public FolderVM(int userId, string folderName)
        {
            UserId = userId;
            FolderName = folderName;
        }

        #endregion
    }
}
