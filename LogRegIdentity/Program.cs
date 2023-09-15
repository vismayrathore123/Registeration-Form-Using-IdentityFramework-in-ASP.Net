using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LogRegIdentity.Areas.Identity.Data;
namespace LogRegIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("LogRegIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'LogRegIdentityContextConnection' not found.");

                                    builder.Services.AddDbContext<LogRegIdentityContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<LogRegIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LogRegIdentityContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
           
        }
    }
}