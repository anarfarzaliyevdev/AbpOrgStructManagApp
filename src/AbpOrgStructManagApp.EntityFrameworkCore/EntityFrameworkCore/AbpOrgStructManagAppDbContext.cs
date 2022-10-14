using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpOrgStructManagApp.Authorization.Roles;
using AbpOrgStructManagApp.Authorization.Users;
using AbpOrgStructManagApp.MultiTenancy;
using AbpOrgStructManagApp.Entities;
using AbpOrgStructManagApp.EntityFrameworkCore.SPModels;

namespace AbpOrgStructManagApp.EntityFrameworkCore
{
    public class AbpOrgStructManagAppDbContext : AbpZeroDbContext<Tenant, Role, User, AbpOrgStructManagAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public virtual DbSet<GetEmployeeTreeOutputSp> GetEmployeeTreeOutputSps { get; set; }

        public virtual DbSet<GetEmployeeTreeManagersWithLevelsSp> GetEmployeeTreeManagersWithLevelsSps { get; set; }
        public AbpOrgStructManagAppDbContext(DbContextOptions<AbpOrgStructManagAppDbContext> options)
            : base(options)
        {
        }
    }
}
