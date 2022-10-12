using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.Entities
{
    public class Employee:Entity,IFullAudited
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get ; set; }
        public DateTime? DeletionTime { get; set ; }
        public bool IsDeleted { get; set; }
        public long? CreatorUserId { get ; set; }
        public long? LastModifierUserId { get ; set; }
        public long? DeleterUserId { get ; set ; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
