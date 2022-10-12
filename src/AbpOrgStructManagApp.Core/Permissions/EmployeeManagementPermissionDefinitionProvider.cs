using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Permissions
{
    public class EmployeeManagementPermissionDefinitionProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var employee = context.CreatePermission("Employee");

            var deleteDirector = employee.CreateChildPermission("Employee.DeleteDirector");
  
        }

    }
}
