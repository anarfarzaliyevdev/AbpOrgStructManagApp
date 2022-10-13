using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AbpOrgStructManagApp.Authorization
{
    public class AbpOrgStructManagAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            var employees = context.CreatePermission(PermissionNames.Employees, L("Employees"));
            var deleteEmployees=employees.CreateChildPermission(PermissionNames.Employees_Delete, L("Employees_Delete"));
            deleteEmployees.CreateChildPermission(PermissionNames.Employees_Delete_Director, L("Employees_Delete_Director"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpOrgStructManagAppConsts.LocalizationSourceName);
        }
    }
}
