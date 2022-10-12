using Abp.Domain.Repositories;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class ManageEmployeeService : IManageEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly List<Employee> _employees=new List<Employee>();
        private readonly List<Employee> _managerEmployees = new List<Employee>();
        private readonly List<EmployeeManagerLevelOutput> _employeeManagerLevelOutputs = new List<EmployeeManagerLevelOutput>();
        private  int _managerLevelCount = 1;
        public ManageEmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("{employeeId}")]
        public async Task<List<Employee>> GetAllDependentEmployees(int employeeId)
        {
            var employee = await _employeeRepository.GetAsync(employeeId);
            var allDependentEmployees = await _employeeRepository.GetAll().Where(e => e.DependId == employeeId).ToListAsync();
            _employees.AddRange(allDependentEmployees);
            while (allDependentEmployees.Count!=0)
            {
                foreach (var emp in allDependentEmployees)
                {
                  
                  return  await GetAllDependentEmployees(emp.Id);
                }
            }

            return _employees;

        }
        [HttpGet("GetAllEmployeesWithManagerLevels/{empId}")]
        public async Task<List<EmployeeManagerLevelOutput>> GetAllEmployeesWithManagerLevels(int empId)
        {
            var employee = await _employeeRepository.GetAsync(empId);
            var managerEmployee = await _employeeRepository.FirstOrDefaultAsync(e=>e.Id==employee.DependId);

           
            while (managerEmployee != null)
            {
                var newOutputModel = new EmployeeManagerLevelOutput() { Name = managerEmployee.Name, Surname = managerEmployee.Surname, ManagerLevel = $"{_managerLevelCount}. Manager" };
                _employeeManagerLevelOutputs.Add(newOutputModel);
                _managerLevelCount++;
                    return await GetAllEmployeesWithManagerLevels(managerEmployee.Id);
              
            }
         
            return _employeeManagerLevelOutputs;

        }

    }
}
