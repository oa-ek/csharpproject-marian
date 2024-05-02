using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using TeamManager.Repository.Users;

namespace TeamManager.Repository
{
    public static class DependencyInjectionRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<RoleManager<IdentityRole<Guid>>>();
        }
    }
}
