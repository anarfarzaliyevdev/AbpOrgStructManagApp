using Abp.Application.Services;
using AbpOrgStructManagApp.MultiTenancy.Dto;

namespace AbpOrgStructManagApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

