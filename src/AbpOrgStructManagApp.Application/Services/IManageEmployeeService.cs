using Abp.Application.Services;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.EntityFrameworkCore.SPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public interface IManageEmployeeService:IApplicationService
    {
        Task<List<GetEmployeeTreeOutputSp>> GetAllDependentEmployees(int empId);
        Task<List<GetEmployeeTreeManagersWithLevelsSp>> GetAllEmployeesWithManagerLevels(int employeeId);
    }
}
