using Abp.Authorization;
using AbpOrgStructManagApp.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class GrantPermissionService : AbpOrgStructManagAppAppServiceBase
    {
        private readonly IPermissionManager _permissionManager;
        private readonly UserManager _userManager;
        public GrantPermissionService(IPermissionManager permissionManager,UserManager userManager)
        {
            _permissionManager = permissionManager;
            _userManager = userManager;
        }
        public async Task GrantUserPermissionAsync(int userId, string permission)
        {
            User currentUser = _userManager.GetUserById(userId);
            var exisitngPemission = _permissionManager.GetPermissionOrNull(permission);
            if (exisitngPemission != null)
            {
                await _userManager.GrantPermissionAsync(currentUser, exisitngPemission);
            }
        }
    }
}
