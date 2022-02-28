using Api.GetPriceFromSite.Dtos;
using Api.GetPriceFromSite.Services;
using Api.GetPriceFromSiteTest.ClassData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.GetPriceFromSiteTest.ServicesTest.IGetPriceServices
{
    public class GetAmazonPrice
    {

        [Theory]
        [ClassData(typeof(GetAmazonPriceClassData))]
        public void GetAmazonPrice_Result_Test(string Url, ResultDto<string> Expected)
        {
            //Arrange

            GetPriceService getPriceService = new GetPriceService();

            //Act
            var Result = getPriceService.GetAmazonPrice(Url);


            //Assert

            Assert.Equal(JsonConvert.SerializeObject(Expected), JsonConvert.SerializeObject(Result));
            Assert.IsType<ResultDto<string>>(Result);
        }

    }
}
