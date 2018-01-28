using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Controllers;
using Shop.Web.Models;
using Xunit;

namespace Shop.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexMethodShouldRetuirnView()
        {
            var controller = new HomeController();

            var expectedResult = controller.Index();

            Assert.NotNull(expectedResult);
            Assert.IsType(typeof(ViewResult), expectedResult);
        }

        [Fact]
        public void ErrorMethodShouldRetuirnViewWithViewModel()
        {
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            };

            var expectedResult = controller.Error() as ViewResult;

            Assert.NotNull(expectedResult);

            var viewModel = expectedResult.Model as ErrorViewModel;

            Assert.NotNull(viewModel);

            Assert.IsType(typeof(ErrorViewModel), viewModel);

        }

    }
}
