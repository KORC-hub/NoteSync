using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using DataAccess.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.SqlServer
{
    public static class DataAccessServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteSyncDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro de UserRepository
            services.AddScoped<IUserRepository<IUser>, UserRepository>();
            services.AddScoped<IMembershipRepository<IMembership>, MembershipRepository>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IMembership, Membership>();

            return services;
        }
    }
}
