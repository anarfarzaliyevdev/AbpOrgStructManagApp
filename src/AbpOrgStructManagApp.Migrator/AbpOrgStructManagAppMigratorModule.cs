using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpOrgStructManagApp.Configuration;
using AbpOrgStructManagApp.EntityFrameworkCore;
using AbpOrgStructManagApp.Migrator.DependencyInjection;

namespace AbpOrgStructManagApp.Migrator
{
    [DependsOn(typeof(AbpOrgStructManagAppEntityFrameworkModule))]
    public class AbpOrgStructManagAppMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpOrgStructManagAppMigratorModule(AbpOrgStructManagAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AbpOrgStructManagAppMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpOrgStructManagAppConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpOrgStructManagAppMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
