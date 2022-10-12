using System.Threading.Tasks;
using AbpOrgStructManagApp.Configuration.Dto;

namespace AbpOrgStructManagApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
