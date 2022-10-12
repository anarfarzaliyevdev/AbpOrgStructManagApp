using System.Threading.Tasks;
using Abp.Application.Services;
using AbpOrgStructManagApp.Authorization.Accounts.Dto;

namespace AbpOrgStructManagApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
