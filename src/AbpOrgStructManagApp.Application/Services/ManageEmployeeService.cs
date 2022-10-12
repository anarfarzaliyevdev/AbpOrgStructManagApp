using Abp.Domain.Repositories;
using AbpOrgStructManagApp.Entities;
using AutoMapper;
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
        private readonly List<Employee> _employees;

        public ManageEmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetAllDependentEmployees(int employeeId)
        {
            var employee = await _employeeRepository.GetAsync(employeeId);
            var allDependentEmployees = await _employeeRepository.GetAll().Where(e => e.DependId == employeeId).ToListAsync();

           return  allDependentEmployees;

        }
        //private async Task<List<Employee>> GetEmployees(List<Employee> employees)
        //{

        //    foreach (var emp in employees)
        //    {
        //        if (emp.DependId != null)
        //        {
        //            var emps = await _employeeRepository.GetAll().Where(e => e.DependId == emp.Id).ToListAsync();
                    

        //        }
                
        //    }
        //    return await GetEmployees(employees);
        //}
    }
}
