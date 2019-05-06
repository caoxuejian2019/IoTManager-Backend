using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class CityModel
    {
        public int Id { get; set; }
        public String CityName { get; set; }
        public String Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
