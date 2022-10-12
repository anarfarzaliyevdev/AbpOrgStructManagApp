using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpOrgStructManagApp.Controllers
{
    public abstract class AbpOrgStructManagAppControllerBase: AbpController
    {
        protected AbpOrgStructManagAppControllerBase()
        {
            LocalizationSourceName = AbpOrgStructManagAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
