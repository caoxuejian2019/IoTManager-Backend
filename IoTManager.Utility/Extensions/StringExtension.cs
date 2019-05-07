using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Utility.Extensions
{
    public static class StringExtension
    {
        public static T ConvertToObj<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
