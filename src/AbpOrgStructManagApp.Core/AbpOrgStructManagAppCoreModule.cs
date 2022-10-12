using Abp.Authorization;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AbpOrgStructManagApp.Authorization.Roles;
using AbpOrgStructManagApp.Authorization.Users;
using AbpOrgStructManagApp.Configuration;
using AbpOrgStructManagApp.Localization;
using AbpOrgStructManagApp.MultiTenancy;
using AbpOrgStructManagApp.Permissions;
using AbpOrgStructManagApp.Timing;

namespace AbpOrgStructManagApp
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpOrgStructManagAppCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpOrgStructManagAppLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpOrgStructManagAppConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            Configuration.Authorization.Providers.Add<EmployeeManagementPermissionDefinitionProvider>();
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AbpOrgStructManagAppConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = AbpOrgStructManagAppConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpOrgStructManagAppCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
