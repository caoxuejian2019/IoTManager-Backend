using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTManager.DAL.Models
{
    public class City
    {
        public int id { get; set; }
        public String cityName { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}