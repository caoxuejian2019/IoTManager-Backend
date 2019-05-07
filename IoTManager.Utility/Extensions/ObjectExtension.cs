using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Utility.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
