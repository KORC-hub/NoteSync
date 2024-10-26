using AutoMapper;
using DataAccess.Abstractions.Models;
using DomainModel;
using DTOs;

namespace BusinessLogic.core
{
    public class BusinessLogicMapping : Profile
    {
        public BusinessLogicMapping()
        {
            // User Mapping
            CreateMap<UserDto, UserDomainModel>();
            CreateMap<UserDomainModel, UserDto>();


            // Folder Mapping
            CreateMap<FolderDto, FolderDomainModel>();
            CreateMap<FolderDomainModel, FolderDto>();

        }
    }
}
