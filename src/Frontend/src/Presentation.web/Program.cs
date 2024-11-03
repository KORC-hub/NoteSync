using Microsoft.AspNetCore.Authentication.Cookies;
using DataAccess.SqlServer;
using BusinessLogic.core;
using BusinessLogic.core.Service;
using BusinessLogic.core.UseCases;

namespace Presentation.web
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

            // autenticaci�n basada en cookies.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie( options =>
                {
                    options.Cookie.Name = Constants.AuthCookie;
                    options.LoginPath = "/Access/Login"; // la ruta de la vista que el usuario utiliza para hacer log in

                    options.Cookie.HttpOnly = true; // solo se podr� acceder a ella a trav�s de peticiones HTTP, lo que mejora la seguridad frente a ataques Cross-Site Scripting
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // la cookie solo se enviar� a trav�s de conexiones HTTPS,previene que se transmita en texto plano a trav�s de HTTP
                    options.Cookie.SameSite = SameSiteMode.Strict; // la cookie no se enviar� junto con solicitudes de sitios externos, previene ataques Cross-Site Request Forgery

                    options.ExpireTimeSpan = TimeSpan.FromDays(1); // Establece el tiempo de expiraci�n de la cookie (1 d�a).
                    options.SlidingExpiration = true; // Cada vez que el usuario interact�a con la aplicaci�n, el tiempo de expiraci�n se renueva,

                });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Landing}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
