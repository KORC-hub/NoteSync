using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.SqlServer
{
    public static class DataAccessDependecies
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteSyncDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro de UserRepository
            services.AddScoped<IUserRepository<IUser>, UserRepository>();
            services.AddScoped<IMembershipRepository<IMembership>, MembershipRepository>();
            services.AddScoped<ITagRepository<ITag>, TagRepository>();
            services.AddScoped<IFolderRepository<IFolder>, FolderRepository>();
            services.AddScoped<IFolderTagRepository<IFolderTag>, FolderTagRepository>();
            services.AddScoped<IPageRepository<IPage>, PageRepository>();

            return services;
        }
    }
}
