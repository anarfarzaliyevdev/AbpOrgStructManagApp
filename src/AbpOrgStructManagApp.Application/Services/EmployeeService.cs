using Abp.Domain.Repositories;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<CreateEmployeeOutput> CreateAsync(CreateEmployeeInput createEmployeeInput)
        {
            var newEmployee = new Employee();
            _mapper.Map(createEmployeeInput, newEmployee);


            return _mapper.Map<CreateEmployeeOutput>(await _employeeRepository.InsertAsync(newEmployee));
        }

        public async Task<DeleteEmployeeOutput> DeleteAsync(int entityId)
        {
            var extinsingEmployee= await _employeeRepository.GetAsync(entityId);
            await _employeeRepository.DeleteAsync(entityId);
            return _mapper.Map<DeleteEmployeeOutput>(extinsingEmployee);
        }

        public async Task<GetEmployeeOutput> GetByIdAsync(int entityId)
        {
            var employee = await _employeeRepository.GetAsync(entityId);
            return _mapper.Map<GetEmployeeOutput>(employee);
        }

        public async Task<UpdateEmployeeOutput> UpdateAsync(UpdateEmployeeInput updateEmployeeInput)
        {
            var employee = _mapper.Map<Employee>(updateEmployeeInput);

            return _mapper.Map<UpdateEmployeeOutput>(await _employeeRepository.UpdateAsync(employee));

        }
    }
}
