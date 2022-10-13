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
    public class GrantPermissionService : IGrantPermissionService
    {
        private readonly IPermissionManager permissionManager;
        private readonly UserManager userManager;
        private readonly IAuthorizationService authorizationService;

        public GrantPermissionService(IPermissionManager permissionManager,UserManager userManager,IAuthorizationService authorizationService)
        {
            this.permissionManager = permissionManager;
            this.userManager = userManager;
            this.authorizationService = authorizationService;
        }
        public async Task GrantUserPermissionAsync(int userId, string permission)
        {
            
            User currentUser = userManager.GetUserById(userId);
            var exisitngPemission = permissionManager.GetPermissionOrNull(permission);
            if (exisitngPemission != null)
            {
                await userManager.GrantPermissionAsync(currentUser, exisitngPemission);
            }
           

        }
    }
}
