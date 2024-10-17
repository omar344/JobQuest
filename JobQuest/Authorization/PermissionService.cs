using JobQuest.Data;
using JobQuest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobQuest.Authorization
{
    public class PermissionService
    {
        private readonly PlatformDataDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionService(PlatformDataDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Assign permissions to a role
        public async Task AssignPermissionsToRole(string roleName, List<string> permissionNames)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) throw new Exception("Role not found");

            foreach (var permissionName in permissionNames)
            {
                var permission = await _dbContext.Permissions.FirstOrDefaultAsync(p => p.Name == permissionName);
                if (permission == null)
                {
                    throw new Exception($"Permission '{permissionName}' not found");
                }

                // Check if the RolePermission already exists
                bool rolePermissionExists = await _dbContext.RolePermissions
                    .AnyAsync(rp => rp.RoleId == role.Id && rp.PermissionId == permission.Id);

                if (!rolePermissionExists)
                {
                    var rolePermission = new RolePermission { RoleId = role.Id, PermissionId = permission.Id };
                    _dbContext.RolePermissions.Add(rolePermission);
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle error
                throw new Exception("Error saving role permissions to the database", ex);
            }
        }

        // Assign permissions to a user
        public async Task AssignPermissionsToUser(ApplicationUser user, List<string> permissionNames)
        {
            foreach (var permissionName in permissionNames)
            {
                var permission = await _dbContext.Permissions.FirstOrDefaultAsync(p => p.Name == permissionName);
                if (permission == null)
                {
                    throw new Exception($"Permission '{permissionName}' not found");
                }

                // Check if the UserPermission already exists
                bool userPermissionExists = await _dbContext.UserPermissions
                    .AnyAsync(up => up.UserId == user.Id && up.PermissionId == permission.Id);

                if (!userPermissionExists)
                {
                    var userPermission = new UserPermission { UserId = user.Id, PermissionId = permission.Id };
                    _dbContext.UserPermissions.Add(userPermission);
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle error
                throw new Exception("Error saving user permissions to the database", ex);
            }
        }
    }
}
