using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    class StringHelper
    {
    }

    public class CamelCaseProvider : ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var value = arg as string;
            if (string.IsNullOrEmpty(value))
                return value;
            return value.Substring(0, 1).ToLower() + value.Substring(1);
        }

        public object GetFormat(Type formatType)
        {
            return this;
        }
    }
}
