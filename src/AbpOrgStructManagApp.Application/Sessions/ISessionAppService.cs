using System.Threading.Tasks;
using Abp.Application.Services;
using AbpOrgStructManagApp.Sessions.Dto;

namespace AbpOrgStructManagApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
