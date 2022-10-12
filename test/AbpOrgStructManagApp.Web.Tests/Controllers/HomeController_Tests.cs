using System.Threading.Tasks;
using AbpOrgStructManagApp.Models.TokenAuth;
using AbpOrgStructManagApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpOrgStructManagApp.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpOrgStructManagAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}