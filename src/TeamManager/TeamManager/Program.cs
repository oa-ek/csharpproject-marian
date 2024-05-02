using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamManager.Core.Contrext;
using TeamManager.Core.Entities;
using TeamManager.Repository;


namespace TeamManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ProjectConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ProjectContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(
             options => {
                 options.SignIn.RequireConfirmedAccount = false;
                 options.Password.RequireDigit = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequiredLength = 5;
             }).AddRoles<IdentityRole<Guid>>()
             .AddEntityFrameworkStores<ProjectContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRepositories();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
