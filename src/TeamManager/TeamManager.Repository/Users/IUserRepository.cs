using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Core.Entities;
using TeamManager.Repository.Common;
using TeamManager.Repository.Models;

namespace TeamManager.Repository.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<IEnumerable<UserListItemModel>> GetAllWithRolesAsync();
        Task<User> CreateWithPasswordAsync(UserCreateModel model);
        Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
        Task<UserListItemModel> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(UserListItemModel model, string[] roles);

        Task<bool> CheckUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
