using System;
using System.Linq;
using System.Text;

namespace Web.Services
{
    public static class Service
    {
        public static int ReturnIdForDelete(string str)
        {
            return Convert.ToInt32(str.ToCharArray().Where(char.IsDigit).Aggregate("", (x, y) => x += y));
        }

        public static string ReturnSomeStars(string str)
        {
            if (str == null)
                return string.Empty;

            var result = new StringBuilder(20);
            char separator = ',';
            byte maxActors = 4;
            byte count = 0;
            foreach (var c in str )
            {
                if (c == separator)
                    ++count;
                if (count == maxActors)
                    return result.ToString();
                result.Append(c);
            }
            return result.ToString();
        }
    }
}