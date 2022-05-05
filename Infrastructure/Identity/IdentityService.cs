using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<(bool Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (true, user.Id);
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null ? await DeleteUserAsync(user) : true;
        }

        public async Task<bool> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return true;
        }
        
        //Additions
        public async Task CreateRole(string roleName)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRole(string roleName)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (roleExists)
                {
                    await _roleManager.DeleteAsync(new IdentityRole(roleName));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetRoles()
        {
            List<string> roles = new List<string>();

            try
            {
                roles = (List<string>)_roleManager.Roles;
            }
            catch (Exception)
            {
                throw;
            }

            return roles;
        }

        public async Task AddUserToRole(string id, string roleName)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (roleExists)
                {
                    var user = await _userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        await _userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveUserFromRole(string id, string roleName)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (roleExists)
                {
                    var user = await _userManager.FindByIdAsync(id);

                    if (user != null)
                    {
                        await _userManager.RemoveFromRoleAsync(user, roleName);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
