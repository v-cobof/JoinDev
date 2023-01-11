using JoinDev.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Validation
{
    public static class DomainValidations
    {
        public static void ShouldNotBeEqualTo(this object obj1, object obj2, string property)
        {
            if (obj1.Equals(obj2))
                throw new DomainException($"The property {property} should not be equal to {obj2}");
        }

        public static void ShouldNotBeEmpty(this string value, string property)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException($"The property '{property}' should not be empty.");
        }

        public static void ShouldNotBeEmpty<T>(this IEnumerable<T> values, string property)
        {
            if (values is null || !values.Any())
                throw new DomainException($"The property '{property}' should not be empty.");
        }

        public static void ShouldNotBeLessThanNorEqualTo(this int value, int minimum, string property)
        {
            if (value <= minimum)
                throw new DomainException($"The property '{property}' should not be less than nor equal to {minimum}");
        }

        public static void ShouldNotBeLessThanNorEqualTo(this decimal value, decimal minimum, string property)
        {
            if (value <= minimum)
                throw new DomainException($"The property '{property}' should not be less than nor equal to {minimum}");
        }
    }
}
