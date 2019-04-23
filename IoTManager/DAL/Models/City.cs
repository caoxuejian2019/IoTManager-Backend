using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTManager.DAL.Models
{
    public class City
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("cityName")]
        public String CityName { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}