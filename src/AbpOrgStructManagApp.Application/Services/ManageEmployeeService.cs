using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Organizations;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class ManageEmployeeService : IManageEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IMemoryCache _memoryCache;
       private readonly string _connectionString=@"Server=HP\SQLEXPRESS; Database=AbpOrgStructManagAppDb; Trusted_Connection=True;TrustServerCertificate=True;";
        public ManageEmployeeService(IRepository<Employee> employeeRepository,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IMemoryCache memoryCache )
        {
            _employeeRepository = employeeRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _memoryCache = memoryCache;
          
        }

      
        [HttpGet("GetAllDependentEmployees/{employeeId}")]
        public async Task<List<EmployeeTreeOutput>> GetAllDependentEmployees(int employeeId)
        {
            var employeeTreeOutputs = new List<EmployeeTreeOutput>();
            var strings = _connectionString;
            using (SqlConnection conn = new SqlConnection(strings))
            {
                conn.Open();

                //create a command 
                SqlCommand cmd = new SqlCommand("GetEmployeeTree", conn);

                //set command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@DepenId", employeeId));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        var employeeTreeItem = new EmployeeTreeOutput();
                        employeeTreeItem.Name = rdr["child_first_name"].ToString();
                        employeeTreeItem.Surname = rdr["child_last_name"].ToString();
                        employeeTreeOutputs.Add(employeeTreeItem);
                    }
                }
            }


            return employeeTreeOutputs;
        }
        [HttpGet("GetAllEmployeesWithManagerLevels/{empId}")]
        public async Task<List<EmployeeManagerLevelOutput>> GetAllEmployeesWithManagerLevels(int empId)
        {

            var employeeTreeOutputs = new List<EmployeeManagerLevelOutput>();
            var strings = _connectionString;
            using (SqlConnection conn = new SqlConnection(strings))
            {
                conn.Open();

                //create a command 
                SqlCommand cmd = new SqlCommand("GetEmployeeManagersWithLevels", conn);

                //set command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@EmpId", empId));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        var employeeTreeItem = new EmployeeManagerLevelOutput();
                        employeeTreeItem.Name = rdr["parent_first_name"].ToString();
                        employeeTreeItem.Surname = rdr["parent_last_name"].ToString();
                        employeeTreeItem.ManagerLevel = rdr["generation_number"].ToString()+". manager";
                        employeeTreeItem.EmployeeType = rdr["parent_employee_type"].ToString();
                        employeeTreeOutputs.Add(employeeTreeItem);
                    }
                }
            }
            return employeeTreeOutputs;

        }

        //[HttpGet("GetAllEmployeesWithManagerLevels/{empId}")]
        //public async Task<List<EmployeeManagerLevelOutput>> GetAllEmployeesWithManagerLevels(int empId)
        //{
        //    await GetEmployees();
        //    var employee = _dbEmployees.FirstOrDefault(e => e.Id == empId);
        //    var managerEmployee = _dbEmployees.FirstOrDefault(e => e.Id == employee.DependId);


        //    while (managerEmployee != null)
        //    {
        //        var newOutputModel = new EmployeeManagerLevelOutput() { Name = managerEmployee.Name, Surname = managerEmployee.Surname, ManagerLevel = $"{_managerLevelCount}. Manager", EmployeeType = managerEmployee.EmployeeType };
        //        _employeeManagerLevelOutputs.Add(newOutputModel);
        //        _managerLevelCount++;
        //        return await GetAllEmployeesWithManagerLevels(managerEmployee.Id);

        //    }

        //    return _employeeManagerLevelOutputs;

        //}
        //[HttpGet("GetAllDependentEmployees/{employeeId}")]
        //public async Task<List<Employee>> GetAllDependentEmployees(int employeeId)
        //{
        //    await GetEmployees();
        //    var employee = _dbEmployees.FirstOrDefault(e=>e.Id==employeeId);
        //    var allDependentEmployees = _dbEmployees.Where(e => e.DependId == employeeId).ToList();
        //    _employees.AddRange(allDependentEmployees);
        //    while (allDependentEmployees.Count != 0)
        //    {
        //        foreach (var emp in allDependentEmployees)
        //        {

        //            return await GetAllDependentEmployees(emp.Id);
        //        }
        //    }

        //    return _employees;

        //}

    }
}
