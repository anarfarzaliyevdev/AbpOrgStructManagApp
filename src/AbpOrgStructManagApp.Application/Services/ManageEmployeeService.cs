using Abp.Configuration.Startup;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Organizations;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.EntityFrameworkCore;
using AbpOrgStructManagApp.EntityFrameworkCore.SPModels;
using AutoMapper;
using AutoMapper.Configuration;
using Castle.Windsor.Installer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class ManageEmployeeService : AbpOrgStructManagAppAppServiceBase
    {
        private readonly IDbContextProvider<AbpOrgStructManagAppDbContext> _dbContextProvider;

        public ManageEmployeeService(IDbContextProvider<AbpOrgStructManagAppDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        [HttpGet("GetAllDependentEmployees/{employeeId}")]
        public async Task<List<GetEmployeeTreeOutputSp>> GetAllDependentEmployees(int employeeId)
        {
            var employeeTreeOutputs = await _dbContextProvider.GetDbContext()
                .GetEmployeeTreeOutputSps.FromSqlInterpolated($"exec [dbo].[GetEmployeeTree] @EmpId={employeeId}").ToListAsync();

            return employeeTreeOutputs;
        }

        [HttpGet("GetAllEmployeesWithManagerLevels/{empId}")]
        public async Task<List<GetEmployeeTreeManagersWithLevelsSp>> GetAllEmployeesWithManagerLevels(int empId)
        {
            var employeeTreeOutputs = await _dbContextProvider.GetDbContext()
                .GetEmployeeTreeManagersWithLevelsSps.FromSqlInterpolated($"exec [dbo].[GetEmployeeManagersWithLevels] @EmpId={empId}").ToListAsync();

            return employeeTreeOutputs;
        }
    }
}
