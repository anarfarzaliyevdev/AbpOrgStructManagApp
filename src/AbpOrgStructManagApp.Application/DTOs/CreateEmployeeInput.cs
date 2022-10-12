using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using AbpOrgStructManagApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOrgStructManagApp.DTOs
{
    [AutoMapTo(typeof(Employee))]
    public class CreateEmployeeInput:ICustomValidate
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int? DependId { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            //DateTime Now = DateTime.Now;
            //int years = new DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year - 1;
            //if (years<18)
            //{
            //    context.Results.Add(new ValidationResult("Employee age must be greater than 18!"));
            //}
        }
    }
}
