using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(bool Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<bool> DeleteUserAsync(string userId);

        Task CreateRole(string roleName);

        Task DeleteRole(string roleName);

        List<string> GetRoles();

        Task AddUserToRole(string id, string roleName);

        Task RemoveUserFromRole(string id, string roleName);

    }
}
