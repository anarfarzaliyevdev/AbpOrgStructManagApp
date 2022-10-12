using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AbpOrgStructManagApp.EntityFrameworkCore.Seed;

namespace AbpOrgStructManagApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpOrgStructManagAppCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AbpOrgStructManagAppEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AbpOrgStructManagAppDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AbpOrgStructManagAppDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AbpOrgStructManagAppDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpOrgStructManagAppEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
