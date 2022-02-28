namespace Api.GetPriceFromSiteTest.ClassData
{
    using Api.GetPriceFromSite.Dtos;
    using Api.GetPriceFromSite.Services;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class GetAmazonPriceClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {

            List<string> Values = new List<string>();

            var InvalidUrlList = new InvalidUrlClassData().GetEnumerator();

            while (InvalidUrlList.MoveNext())
            {
                Values.Add(InvalidUrlList?.Current?.GetValue(0)?.ToString());
            }

            var validUrlList = new ValidUrlClassData().GetEnumerator();

            while (validUrlList.MoveNext())
            {
                Values.Add(validUrlList?.Current?.GetValue(0)?.ToString());
            }

            Values.Add("amazon.com");
            Values.Add("www.amazon.com");
            Values.Add("http://amazon.com");
            Values.Add("http://www.amazon.com");
            Values.Add("https://amazon.com");
            Values.Add("https://www.amazon.com");


            foreach (var item in Values)
            {
                if (string.IsNullOrEmpty(item))
                {
                    yield return new object[]
                    {
                        item , new ResultDto<string>
                        {
                            IsSuccess = false,
                            Message = "Url Not Inserted",
                            Data = null,
                        }
                    };
                }
                else if (!CheckUrl.IsExistUrl(item).IsSuccess)
                {
                    yield return new object[]
                    {
                       item , new ResultDto<string>
                       {
                            IsSuccess = false,
                            Message = CheckUrl.IsExistUrl(item).Message,
                            Data = null,
                       }
                    };
                }

                else if (!item.ToLower().Contains("amazon.com"))
                {
                    yield return new object[]
                    {
                         item,new ResultDto<string>
                         {
                            IsSuccess = false,
                            Message = "Url Is Not For Amazon Site",
                            Data = null,
                         }
                    };
                }
                else
                {
                    yield return new object[]
                    {
                         item,new ResultDto<string>
                         {
                            IsSuccess = true,
                            Message = "This Product Dont Have Current Price",
                            Data = "0$",
                         }
                    };
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
