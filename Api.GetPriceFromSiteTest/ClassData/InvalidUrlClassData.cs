using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GetPriceFromSiteTest.ClassData
{
    public class InvalidUrlClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "" };
            yield return new object[] { null };
            yield return new object[] { "jhgghjgjhgjg" };
            yield return new object[] { "jhggh.hghg.gbbg" };
            yield return new object[] { "http://hghghg" };
            yield return new object[] { "http://hghghg.sss.ddd" };
            yield return new object[] { "hhfhgfhf.com" };
            yield return new object[] { "www.hhfhgfhf.com" };
            yield return new object[] { "http://www.hhfhgfhf.com" };
            yield return new object[] { "https://www.hhfhgfhf.com" };
            yield return new object[] { "https://hhfhgfhf.com" };
            yield return new object[] { "http://hhfhgfhf.com" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
