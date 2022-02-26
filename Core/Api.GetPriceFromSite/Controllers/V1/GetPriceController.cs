using Api.GetPriceFromSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.GetPriceFromSite.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GetPriceController : ControllerBase
    {
        private readonly IGetPriceService getPriceService;

        public GetPriceController(IGetPriceService getPriceService)
        {
            this.getPriceService = getPriceService;
        }

        [HttpPost]
        public IActionResult GetPrice(string Url)
        {
            var Result = getPriceService.GetAmazonPrice(Url);
            if (!Result.IsSuccess)
            {
                return NotFound(Result);
            }

            return Ok(Result);
        }
    }
}
