using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpOrgStructManagApp.EntityFrameworkCore;
using AbpOrgStructManagApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AbpOrgStructManagApp.Web.Tests
{
    [DependsOn(
        typeof(AbpOrgStructManagAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AbpOrgStructManagAppWebTestModule : AbpModule
    {
        public AbpOrgStructManagAppWebTestModule(AbpOrgStructManagAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpOrgStructManagAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AbpOrgStructManagAppWebMvcModule).Assembly);
        }
    }
}