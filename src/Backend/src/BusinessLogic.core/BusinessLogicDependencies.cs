using DataAccess.Abstractions.Models;
using DataAccess.SqlServer.Models;
using DataAccess.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Repositories;
using DataAccess.Abstractions.UoW;

namespace BusinessLogic.core
{
    public static class BusinessLogicDependencies
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoriesManager, RepositoriesManager>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IMembership, Membership>();
            services.AddScoped<IFolder, Folder>();
            services.AddScoped<ITag, Tag>();
            services.AddScoped<IFolderTag, FolderTag>();

            return services;
        }
    }
}
