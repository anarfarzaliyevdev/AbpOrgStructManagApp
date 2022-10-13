using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public interface IGrantPermissionService:IApplicationService
    {
        Task GrantUserPermissionAsync(int userId, string permission);
    }
}
