using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Queries.Extensions
{
    public static class Utils
    {
        public static bool NotDefault<T>(this T value)
        {
            return !EqualityComparer<T>.Default.Equals(value, default);
        }
    }
}
