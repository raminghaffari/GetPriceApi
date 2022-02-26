using AngleSharp;
using Api.GetPriceFromSite.Dtos;
using System.Linq;
using System.Net;

namespace Api.GetPriceFromSite.Services
{
    public class GetPriceService : IGetPriceService
    {
        public ResultDto<string> GetAmazonPrice(string Url)
        {
            //----! Check Url Is Empty Or Null

            if (string.IsNullOrEmpty(Url))
            {
                return new ResultDto<string>
                {
                    IsSuccess = false,
                    Message = "Url Not Inserted",
                };
            }

            //----! Check Url Have Http Or Https

            if (!Url.ToLower().Contains("http://") && !Url.ToLower().Contains("https://"))
            {
                Url = "https://" + Url;
            }


            //----! Check Url Is Valid

            var ExistUrl = CheckUrl.IsExistUrl(Url);

            if (!ExistUrl.IsSuccess)
            {
                return new ResultDto<string>
                {
                    IsSuccess = false,
                    Message = ExistUrl.Message,
                };
            }



            //----! Check Url Is For Amazon Site

            if (!Url.ToLower().Contains("amazon.com"))
            {
                return new ResultDto<string>
                {
                    IsSuccess = false,
                    Message = "Url Is Not For Amazon Site",
                };
            }


            //----! Get Page Html With AngleSharp

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


            //----! Get Price From Doucument With Selector

            var cellselector = "#price_inside_buybox";
            var cell = doucument.QuerySelectorAll(cellselector);
            if (cell.Length <= 0)
            {
                return new ResultDto<string>
                {
                    IsSuccess = true,
                    Message = "This Product Dont Have Current Price",
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
