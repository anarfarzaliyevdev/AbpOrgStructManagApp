using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.EntityFrameworkCore.SPModels
{
    [Keyless]
    public class GetEmployeeTreeOutputSp
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
