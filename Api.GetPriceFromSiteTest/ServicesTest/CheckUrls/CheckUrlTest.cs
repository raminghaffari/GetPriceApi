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

namespace Api.GetPriceFromSiteTest.ServicesTest.CheckUrls
{
    public class CheckUrlTest
    {

        [Theory]
        [ClassData(typeof(ValidUrlClassData))]
        public void ValidOrExistUrlTest(string ValidUrl)
        {
            //Arrange 
            ResultDto ExpectedValidResult = new ResultDto
            {
                IsSuccess = true,
                Message = null
            };

            //Act
            var ResultValidUrl = CheckUrl.IsExistUrl(ValidUrl);



            //Assert
            {
                Assert.IsType<ResultDto>(ResultValidUrl);
                Assert.Equal(JsonConvert.SerializeObject(ExpectedValidResult), JsonConvert.SerializeObject(ResultValidUrl));
            }
        }


        [Theory]
        [ClassData(typeof(InvalidUrlClassData))]
        public void InvalidUrlTest(string InvalidUrl)
        {
            //Arrange

            ResultDto ExpectedValidResult = new ResultDto
            {
                IsSuccess = false,
                Message = "Url Not Valid Or Exist",
            };

            //Act

            var ResultInvalidUrl = CheckUrl.IsExistUrl(InvalidUrl);

            //Assert

            Assert.IsType<ResultDto>(ResultInvalidUrl);
            Assert.Equal(JsonConvert.SerializeObject(ExpectedValidResult), JsonConvert.SerializeObject(ResultInvalidUrl));

        }
    }
}
