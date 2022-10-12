using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Entities
{
    public class Department:Entity,IHasCreationTime,ISoftDelete
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set ; }
        public virtual List<Employee> Employees { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
