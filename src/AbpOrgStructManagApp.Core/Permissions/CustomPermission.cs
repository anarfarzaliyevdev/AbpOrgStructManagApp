using Abp.Application.Features;
using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Permissions
{
    public class CustomPermission : Permission
    {
        public CustomPermission(string name, ILocalizableString displayName = null, ILocalizableString description = null, MultiTenancySides multiTenancySides = MultiTenancySides.Tenant | MultiTenancySides.Host, IFeatureDependency featureDependency = null, Dictionary<string, object> properties = null) : base(name, displayName, description, multiTenancySides, featureDependency, properties)
        {
        }
    }
}
