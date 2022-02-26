using AngleSharp;
using Api.GetPriceFromSite.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.GetPriceFromSite.Services
{
    public interface IGetPriceService
    {
        ResultDto<string> GetAmazonPrice(string Url);
    }

    public class GetPriceService : IGetPriceService
    {
        public ResultDto<string> GetAmazonPrice(string Url)
        {

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var doucument = context.OpenAsync(Url).Result;

            if (doucument == null || doucument.StatusCode != HttpStatusCode.OK)
            {
                return new ResultDto<string>
                {
                    IsSuccess = false,
                    Message = "Url Not Found",
                };
            }


            var cellselector = "#price_inside_buybox";
            var cell = doucument.QuerySelectorAll(cellselector);
            if (cell.Length <= 0)
            {
                return new ResultDto<string>
                {
                    IsSuccess = true,
                    Message = "Price Not Found",
                    Data = "0$",
                };
            }

            var Price = cell.Select(p => p.TextContent).FirstOrDefault();

            if (Price == null)
            {
                return new ResultDto<string>
                {
                    IsSuccess = true,
                    Message = "Price Not Found",
                    Data = "0$",
                };
            }


            return new ResultDto<string>
            {
                IsSuccess = true,
                Message = "Price received successfully",
                Data = Price,
            };
        }


    }
}
