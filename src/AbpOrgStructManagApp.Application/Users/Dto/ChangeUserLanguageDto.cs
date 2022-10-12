using System.ComponentModel.DataAnnotations;

namespace AbpOrgStructManagApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}