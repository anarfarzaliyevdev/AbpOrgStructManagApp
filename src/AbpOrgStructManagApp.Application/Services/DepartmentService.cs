using Abp.Domain.Repositories;
using AbpOrgStructManagApp.DTOs;
using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Services
{
    public class DepartmentService : AbpOrgStructManagAppAppServiceBase
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<Department>> GetAllAsync()
        {
           return await _departmentRepository.GetAllListAsync();
        }
        public async Task DeleteAsync(int entityId)
        {
             await _departmentRepository.DeleteAsync(entityId); ;
        }
    }
}
