using Abp.Authorization;
using Abp.Domain.Repositories;
using AbpOrgStructManagApp.Authorization;
using AbpOrgStructManagApp.Authorization.Users;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly UserManager userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPermissionChecker permissionChecker;
        private readonly PermissionManager permissionManager;

        public EmployeeService(IRepository<Employee> employeeRepository, IDepartmentService departmentService,
            IMapper mapper, UserManager userManager,IHttpContextAccessor httpContextAccessor,IPermissionChecker permissionChecker,PermissionManager permissionManager)
        {
            _employeeRepository = employeeRepository;
            _departmentService = departmentService;
            _mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.permissionChecker = permissionChecker;
            this.permissionManager = permissionManager;
        }
        [AbpAuthorize(PermissionNames.Employees)]
        public async Task<CreateEmployeeOutput> CreateAsync(CreateEmployeeInput createEmployeeInput)
        {
            var newEmployee = new Employee();
            _mapper.Map(createEmployeeInput, newEmployee);


            return _mapper.Map<CreateEmployeeOutput>(await _employeeRepository.InsertAsync(newEmployee));
        }

        [AbpAuthorize(PermissionNames.Employees_Delete)]
        public async Task<DeleteEmployeeOutput> DeleteAsync(int entityId)
        {
          
            var extinsingEmployee= await _employeeRepository.GetAsync(entityId);
            if (extinsingEmployee.EmployeeType == EmployeeTypes.Director.ToString())
            {
                if (!permissionChecker.IsGranted(PermissionNames.Employees_Delete_Director))
                {
                    throw new AbpAuthorizationException("You are not authorized to remove director employee!");
                } 

            }
            
            await _employeeRepository.DeleteAsync(entityId);
            if (extinsingEmployee.DepartmentId != null)
            {
                var employees = await (GetAllByDepIdAsync((int)extinsingEmployee.DepartmentId));
                if (employees.Count == 1)
                {
                    await _departmentService.DeleteAsync((int)extinsingEmployee.DepartmentId);
                }
            }
            return _mapper.Map<DeleteEmployeeOutput>(extinsingEmployee);
        }
        [AbpAuthorize(PermissionNames.Employees)]
        public async Task<GetEmployeeOutput> GetByIdAsync(int entityId)
        {
            var employee = await _employeeRepository.GetAsync(entityId);
            return _mapper.Map<GetEmployeeOutput>(employee);
        }
        [AbpAuthorize(PermissionNames.Employees)]
        public async Task<UpdateEmployeeOutput> UpdateAsync(UpdateEmployeeInput updateEmployeeInput)
        {
            var employee = _mapper.Map<Employee>(updateEmployeeInput);

            return _mapper.Map<UpdateEmployeeOutput>(await _employeeRepository.UpdateAsync(employee));

        }
        [AbpAuthorize(PermissionNames.Employees)]
        private async Task<List<Employee>> GetAllByDepIdAsync(int depId)
        {
            var employees = (await _employeeRepository.GetAllListAsync()).Where(e=>e.DepartmentId==depId).ToList();
            return employees;
        }
    }
}
