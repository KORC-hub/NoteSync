using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.SqlServer.Models;

namespace DataAccess.SqlServer
{
    public class DataAccessMapping : Profile
    {
        public DataAccessMapping()
        {
            // User Mapping
            CreateMap<IUser, User>();
            CreateMap<User, IUser>();

            // Folder Mapping
            CreateMap<IFolder, Folder>();
            CreateMap<Folder, IFolder>();

            // Tag Mapping
            CreateMap<ITag, Tag>();
            CreateMap<Tag, ITag>();

            // FolderTag Mapping
            CreateMap<IFolderTag, FolderTag>();
            CreateMap<FolderTag, IFolderTag>();
        }
    }
}
