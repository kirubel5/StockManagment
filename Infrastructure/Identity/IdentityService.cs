using Application.Common.Interfaces;
using Application.Common.Models.Identity;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.IdentityModel.Configuration;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly IdentityConfiguration _identityConfiguration;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService,
            IdentityConfiguration identityConfiguration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _identityConfiguration = identityConfiguration;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                return null;

            return user.UserName;
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            var user = await _userManager.Users?.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return null;

            return user.Id;
        }

        public List<string> GetAllUserNames()
        {
            List<string> userNames = new();
            var users = _userManager.Users;

            if (users != null && users.Count() > 0)
            {
                foreach (var item in users)
                {
                    userNames.Add(item.UserName);
                }
            }

            return userNames;
        }

        public async Task<(bool Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
                return (true, user.Id);
            else
                return (false, user.Id);
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
                    await _roleManager.DeleteAsync(await _roleManager.FindByNameAsync(roleName));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetRoles()
        {
            List<string> roleNames = new();
            try
            {
                var roles = _roleManager.Roles;

                foreach (var item in roles)
                {
                    roleNames.Add(item.Name);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return roleNames;
        }

        public async Task<string> GetUserRole(string userName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                var userRole = await _userManager.GetRolesAsync(user);
                return userRole.First();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<string> GetRoleId(string roleName)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (roleExists)
                {
                    var a = await _roleManager.FindByNameAsync(roleName);
                    return a.Id;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetRoleNameById(string roleId)
        {
            try
            {
                var a = await _roleManager.FindByIdAsync(roleId);
                return a.Name;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetRoleIdByName(string roleName)
        {
            try
            {
                var a = await _roleManager.FindByNameAsync(roleName);
                return a.Id;
            }
            catch (Exception)
            {
                throw;
            }
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
       
        private async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var userClaims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, user.UserName),
                new Claim(JwtClaimTypes.Id, user.Id)
            };

            userClaims.AddRange(await _userManager.GetClaimsAsync(user));

            userClaims.AddRange((await _userManager.GetRolesAsync(user))
                .Select(role => new Claim(JwtClaimTypes.Role, role)));

            return userClaims;
        }

        private async Task<AuthenticationResponse> GenerateJwtForUserAsync(ApplicationUser user)
        {
            var userClaims = await GetClaimsAsync(user);

            var expiresOn = DateTime.Now.AddDays(_identityConfiguration.DaysBeforeExpiration);

            var token = new JwtSecurityToken(
                _identityConfiguration.TokenIssuer,
                _identityConfiguration.TokenAudience,
                expires: expiresOn,
                claims: userClaims,
                signingCredentials: new SigningCredentials(
                    _identityConfiguration.SecurityKey,
                    _identityConfiguration.SecurityAlgorithm)
            );

            return new AuthenticationResponse
            {
                ExpireOn = token.ValidTo,
                Token = new JwtSecurityTokenHandler()
                    .WriteToken(token)
            };
        }

        public async Task<AuthenticationResponse> GetJwtForUserAsync(string username, string password)
        {
            var userAuthentication = await GetAuthenticatedUserAsync(username, password);
           
            return userAuthentication == null
                ? null
                : await GenerateJwtForUserAsync(userAuthentication);
        }

        private async Task<ApplicationUser> GetAuthenticatedUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user != null
                   && await _userManager.CheckPasswordAsync(user, password)
                ? user
                : null;
        }
    }
}
