using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.DTOs
{
    [AutoMapFrom(typeof(Employee))]
    public class GetEmployeeOutput
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
