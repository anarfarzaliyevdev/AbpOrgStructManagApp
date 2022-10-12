using Abp.Application.Services;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public interface IEmployeeService : IApplicationService
    {
        Task<CreateEmployeeOutput> CreateAsync(CreateEmployeeInput input);
        Task<UpdateEmployeeOutput> UpdateAsync(UpdateEmployeeInput input);
        Task<DeleteEmployeeOutput> DeleteAsync(int entityId);
        Task<GetEmployeeOutput> GetByIdAsync(int entityId);
       
    }
}
