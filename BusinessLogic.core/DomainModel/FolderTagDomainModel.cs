using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FolderTagDomainModel
    {
        #region Private Variable

        private int _fileId;
        private int _tagId;

        #endregion

        #region Public Variable
        public int FileId { get => _fileId; set => _fileId = value; }
        public int TagId { get => _tagId; set => _tagId = value; }
        #endregion

        #region Constructors

        public FolderTagDomainModel()
        {

        }
        public FolderTagDomainModel(int fileId, int tagId)
        {
            _fileId = fileId;
            _tagId = tagId;
        }
        #endregion
    }
}
