using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public interface IManageEmployeeService
    {
        Task<List<Employee>> GetAllDependentEmployees(int employeeId);
    }
}
