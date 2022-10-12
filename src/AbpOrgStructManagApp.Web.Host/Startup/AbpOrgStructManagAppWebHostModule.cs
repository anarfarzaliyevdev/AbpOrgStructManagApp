using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpOrgStructManagApp.Configuration;

namespace AbpOrgStructManagApp.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpOrgStructManagAppWebCoreModule))]
    public class AbpOrgStructManagAppWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpOrgStructManagAppWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpOrgStructManagAppWebHostModule).GetAssembly());
        }
    }
}
