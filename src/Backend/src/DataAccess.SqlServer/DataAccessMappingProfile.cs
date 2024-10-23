using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.SqlServer.Models;

namespace DataAccess.SqlServer
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<IUser, User>();
            CreateMap<User, IUser>();
        }
    }
}
