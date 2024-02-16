using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Helpers
{
    public class CommonHelper
    {
        public static DateTime ConvertStringToDate(string dateString)
        {
            DateTime dateTime;

            if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
            {
                throw new ArgumentException("Date string is not in expected format (yyyy-MM-dd).");
            }
        }
    }
}
