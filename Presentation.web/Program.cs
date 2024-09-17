using System.Security.Policy;

namespace Presentation.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // autenticaci�n basada en cookies.
            builder.Services.AddAuthentication(Constants.AuthScheme)
                .AddCookie(Constants.AuthScheme, options =>
                {
                    options.Cookie.Name = Constants.AuthCookie;
                    options.LoginPath = "/Auth/Login"; // la ruta de la vista que el usuario utiliza para hacer log in
                    options.AccessDeniedPath = "/Auth/access-denied"; // vista que se le mostrara el usuario si se niega el acceso
                    options.LogoutPath = "/Auth/logout"; // vista que se le mostrara al usuario si hace log out

                    options.Cookie.HttpOnly = true; // solo se podr� acceder a ella a trav�s de peticiones HTTP, lo que mejora la seguridad frente a ataques Cross-Site Scripting
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // la cookie solo se enviar� a trav�s de conexiones HTTPS,previene que se transmita en texto plano a trav�s de HTTP
                    options.Cookie.SameSite = SameSiteMode.Strict; // la cookie no se enviar� junto con solicitudes de sitios externos, previene ataques Cross-Site Request Forgery

                    options.ExpireTimeSpan = TimeSpan.FromDays(1); // Establece el tiempo de expiraci�n de la cookie (1 d�a).
                    options.SlidingExpiration = true; // Cada vez que el usuario interact�a con la aplicaci�n, el tiempo de expiraci�n se renueva,

                });



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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
