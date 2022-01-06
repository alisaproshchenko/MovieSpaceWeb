using System;
using System.Linq;

namespace Web.Services
{
    public static class Service
    {
        public static int ReturnIdForDelete(string str)
        {
            return Convert.ToInt32(str.ToCharArray().Where(char.IsDigit).Aggregate("", (x, y) => x += y));
        }
    }
}