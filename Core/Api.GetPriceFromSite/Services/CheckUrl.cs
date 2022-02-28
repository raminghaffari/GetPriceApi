using Api.GetPriceFromSite.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.GetPriceFromSite.Services
{
    public static class CheckUrl
    {
        /// <summary>
        /// Check Url Is Valid And Exist Or Not
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static ResultDto IsExistUrl(string Url)
        {
            try
            {
                if (!Url.ToLower().Contains("http://") && !Url.ToLower().Contains("https://"))
                {
                    Url = "https://" + Url;
                }

                var request = WebRequest.Create(Url) as HttpWebRequest;
                request.Timeout = 15000;
                request.Method = HttpMethod.Get.ToString();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = null
                    };
                }
            }
            catch (Exception)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Url Not Valid Or Exist",
                };
            }
        }
    }
}
