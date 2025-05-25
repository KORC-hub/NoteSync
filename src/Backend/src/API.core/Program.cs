using DataAccess.SqlServer;
using BusinessLogic.core;
using BusinessLogic.core.Service;
using BusinessLogic.core.UseCases;

namespace API.core
{
    public class Program
    {
        public static void Main(string[] args)  
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SQLServer");
            builder.Services.AddDataAccessServices(connectionString);
            builder.Services.AddBusinessLogicServices();

            builder.Services.AddScoped<IUserUseCases, UserService>();
            builder.Services.AddScoped<IFolderUseCases, FolderService>();

            builder.Services.AddAutoMapper(typeof(BusinessLogicMapping));
            builder.Services.AddAutoMapper(typeof(DataAccessMapping));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
