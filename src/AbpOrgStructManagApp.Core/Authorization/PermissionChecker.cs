using Abp.Authorization;
using AbpOrgStructManagApp.Authorization.Roles;
using AbpOrgStructManagApp.Authorization.Users;

namespace AbpOrgStructManagApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
