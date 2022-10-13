﻿using Abp.Application.Services;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public interface IManageEmployeeService:IApplicationService
    {
        Task<List<EmployeeTreeOutput>> GetAllDependentEmployees(int empId);
        Task<List<EmployeeManagerLevelOutput>> GetAllEmployeesWithManagerLevels(int employeeId);
    }
}
