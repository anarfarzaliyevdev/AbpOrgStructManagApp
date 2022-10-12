using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpOrgStructManagApp.Authorization;

namespace AbpOrgStructManagApp
{
    [DependsOn(
        typeof(AbpOrgStructManagAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpOrgStructManagAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpOrgStructManagAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpOrgStructManagAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
