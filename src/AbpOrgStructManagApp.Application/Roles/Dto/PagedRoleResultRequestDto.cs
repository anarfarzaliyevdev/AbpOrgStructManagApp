using Abp.Application.Services.Dto;

namespace AbpOrgStructManagApp.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

