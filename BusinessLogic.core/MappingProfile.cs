using AutoMapper;
using DataAccess.SqlServer.Models;
using Entities;

namespace BusinessLogic.core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTO's to DomainModels
            CreateMap<UserDto, UserDomainModel>();

            // DomainModels to DTO's
            CreateMap<UserDomainModel, UserDto>();

            // DM(Data Models) to DomainModels
            CreateMap<User, UserDomainModel>();

            // DomainModels to DM(Data Models)
            CreateMap<UserDomainModel, User>();

        }
    }
}
