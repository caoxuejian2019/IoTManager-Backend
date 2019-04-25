using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

namespace IoTManager.DAL.Models
{
    public class Factory
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("factoryName")]
        public String FactoryName { get; set; }
        
        
        [Column("factoryPhoneNumber")]
        public String FactoryPhoneNumber { get; set; }
        
        
        [Column("factoryAddress")]
        public String FactoryAddress { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
        
        
        [Column("city")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}