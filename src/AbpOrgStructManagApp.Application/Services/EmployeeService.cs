using Abp.Authorization;
using Abp.Domain.Repositories;
using AbpOrgStructManagApp.Authorization;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class EmployeeService : AbpOrgStructManagAppAppServiceBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IPermissionChecker _permissionChecker;

        public EmployeeService(IRepository<Employee> employeeRepository,
            IDepartmentService departmentService, IMapper mapper, IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
            _employeeRepository = employeeRepository;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Employees)]
        public async Task<CreateEmployeeOutput> CreateAsync(CreateEmployeeInput createEmployeeInput)
        {
            var newEmployee = _mapper.Map<Employee>(createEmployeeInput);
            return _mapper.Map<CreateEmployeeOutput>(await _employeeRepository.InsertAsync(newEmployee));
        }

        [AbpAuthorize(PermissionNames.Employees_Delete)]
        public async Task DeleteAsync(int entityId)
        {
            var extinsingEmployee = await _employeeRepository.GetAsync(entityId);
            if (extinsingEmployee.EmployeeType == EmployeeTypes.Director.ToString())
            {
                if (!_permissionChecker.IsGranted(PermissionNames.Employees_Delete_Director))
                {
                    throw new AbpAuthorizationException("You are not authorized to remove director employee!");
                }
            }

            await _employeeRepository.DeleteAsync(entityId);

            if (extinsingEmployee.DepartmentId.HasValue && await ShoudIRemoveRelatedDepartment(extinsingEmployee.Id, extinsingEmployee.DepartmentId.Value))
            {
                await _departmentService.DeleteAsync((int)extinsingEmployee.DepartmentId);
            }
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
            var employee = await _employeeRepository.GetAsync(updateEmployeeInput.Id);
            _mapper.Map(updateEmployeeInput, employee);

            return _mapper.Map<UpdateEmployeeOutput>(await _employeeRepository.UpdateAsync(employee));
        }

        [AbpAuthorize(PermissionNames.Employees)]
        private async Task<bool> ShoudIRemoveRelatedDepartment(int currentEmployeeId, int depId)
        {
            return await _employeeRepository.GetAll().Where(e => e.Id != currentEmployeeId && e.DepartmentId == depId).CountAsync() == 0;
        }
    }
}
