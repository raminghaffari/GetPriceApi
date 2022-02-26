using Api.GetPriceFromSite.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.GetPriceFromSite.Services
{
    public interface IGetPriceService
    {
        ResultDto<string> GetAmazonPrice(string Url);
    }
}
