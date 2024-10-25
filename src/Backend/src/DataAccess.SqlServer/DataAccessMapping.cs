using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.SqlServer.Models;

namespace DataAccess.SqlServer
{
    public class DataAccessMapping : Profile
    {
        public DataAccessMapping()
        {
            CreateMap<IUser, User>();
            CreateMap<User, IUser>();
        }
    }
}
