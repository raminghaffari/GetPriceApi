using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.GetPriceFromSiteTest.ClassData
{
    public class ValidUrlClassData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] { "http://www.Google.com" };
            yield return new object[] { "https://www.Google.com" };
            yield return new object[] { "http://Google.com" };
            yield return new object[] { "https://Google.com" };
            yield return new object[] { "http://support.Google.com" };
            yield return new object[] { "https://support.Google.com" };
            yield return new object[] { "http://www.support.Google.com" };
            yield return new object[] { "https://www.support.Google.com" };
            yield return new object[] { "Google.com" };
            yield return new object[] { "support.Google.com" };
            yield return new object[] { "http://support.Google.com/path/to/dir/" };
            yield return new object[] { "https://support.Google.com/path/to/dir/" };
            yield return new object[] { "http://www.support.Google.com/path/to/dir/" };
            yield return new object[] { "https://www.support.Google.com/path/to/dir/" };
            yield return new object[] { "support.Google.com/path/to/dir/" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
