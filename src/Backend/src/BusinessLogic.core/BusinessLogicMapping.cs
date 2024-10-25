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
            // DTO's to DomainModels
            CreateMap<UserDto, UserDomainModel>();

            // DomainModels to DTO's
            CreateMap<UserDomainModel, UserDto>();

            // DM(Data Models) to DomainModels
            CreateMap<IUser, UserDomainModel>();

            // DomainModels to DM(Data Models)
            CreateMap<UserDomainModel, IUser>();

        }
    }
}
