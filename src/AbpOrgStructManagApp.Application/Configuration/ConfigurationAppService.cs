using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpOrgStructManagApp.Configuration.Dto;

namespace AbpOrgStructManagApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpOrgStructManagAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
