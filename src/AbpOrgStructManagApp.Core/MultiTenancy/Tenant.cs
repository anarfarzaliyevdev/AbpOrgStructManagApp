using Abp.MultiTenancy;
using AbpOrgStructManagApp.Authorization.Users;

namespace AbpOrgStructManagApp.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
