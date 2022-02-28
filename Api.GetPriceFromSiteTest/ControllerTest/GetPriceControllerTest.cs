using Api.GetPriceFromSite.Dtos;
using Api.GetPriceFromSite.Services;
using Api.GetPriceFromSite.V1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace Api.GetPriceFromSiteTest.ControllerTest
{
    public class GetPriceControllerTest
    {

        [Fact]
        public void GetPrice_Test()
        {
            //Arrange
            var Moq = new Mock<IGetPriceService>();
            Moq.Setup(p => p.GetAmazonPrice("Amazon.com")).Returns(new ResultDto<string> { Data = "25$", IsSuccess = true, Message = "Price received successfully" });
            Moq.Setup(p => p.GetAmazonPrice("Google.com")).Returns(new ResultDto<string> { Data = "0$", IsSuccess = false, Message = "Not Found" });

            GetPriceController controller = new GetPriceController(Moq.Object);

            //Act

            var ResultOk = controller.GetPrice("Amazon.com");
            var ResultNotFound = controller.GetPrice("Google.com");

            //Assert

            Assert.IsType<OkObjectResult>(ResultOk);
            Assert.IsType<NotFoundObjectResult>(ResultNotFound);

            var ResultOkValue = ResultOk as OkObjectResult;
            Assert.IsType<ResultDto<string>>(ResultOkValue.Value);

            var ResultNotFoundValue = ResultNotFound as NotFoundObjectResult;
            Assert.IsType<ResultDto<string>>(ResultNotFoundValue.Value);
        }
    }
}
