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
    public class ManageEmployeeService : IManageEmployeeService
    {

        private readonly IDbContextProvider<AbpOrgStructManagAppDbContext> dbContextProvider;

        public ManageEmployeeService(IDbContextProvider<AbpOrgStructManagAppDbContext> dbContextProvider)
        {

            this.dbContextProvider = dbContextProvider;
        }
        [HttpGet("GetAllDependentEmployees/{employeeId}")]
        public async Task<List<GetEmployeeTreeOutputSp>> GetAllDependentEmployees(int employeeId)
        {
            //first way of getting data 

            //var employeeTreeOutputs = await dbContextProvider.GetDbContext()
            //    .GetEmployeeTreeOutputSps.FromSqlInterpolated($"exec [dbo].[GetEmployeeTree] @EmpId={employeeId}").ToListAsync();
            // second way of getting data
            var parameter = new SqlParameter()
            {
                ParameterName = "@EmpId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = employeeId
            };
            var employeeTreeOutputs = await dbContextProvider.GetDbContext()
               .GetEmployeeTreeOutputSps.FromSqlRaw("exec [dbo].[GetEmployeeTree] @EmpId", parameter).ToListAsync();

            return employeeTreeOutputs;
        }
        [HttpGet("GetAllEmployeesWithManagerLevels/{empId}")]
        public async Task<List<GetEmployeeTreeManagersWithLevelsSp>> GetAllEmployeesWithManagerLevels(int empId)
        {
            //first way of getting data 

            //var employeeTreeOutputs = await dbContextProvider.GetDbContext()
            //    .GetEmployeeTreeManagersWithLevelsSps.FromSqlInterpolated($"exec [dbo].[GetEmployeeManagersWithLevels] @EmpId={empId}").ToListAsync();
            // second way of getting data
            var parameter = new SqlParameter()
            {
                ParameterName = "@EmpId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = empId
            };
            var employeeTreeOutputs = await dbContextProvider.GetDbContext()
               .GetEmployeeTreeManagersWithLevelsSps.FromSqlRaw("exec [dbo].[GetEmployeeManagersWithLevels] @EmpId", parameter).ToListAsync();

            return employeeTreeOutputs;

        }

    }
}
