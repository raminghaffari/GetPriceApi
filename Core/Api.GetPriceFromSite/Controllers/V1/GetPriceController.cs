using Api.GetPriceFromSite.Dtos;
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
        private readonly IGetPriceService _getPriceService;

        public GetPriceController(IGetPriceService getPriceService)
        {
            _getPriceService = getPriceService;
        }

        [HttpPost]
        public IActionResult GetPrice(string Url)
        {
            var Result = _getPriceService.GetAmazonPrice(Url);
            if (!Result.IsSuccess)
            {
                return NotFound(Result);
            }

            return Ok(Result);
        }
    }
}
