using System;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

namespace IoTManager.DAL.Models
{
    public class DeviceType
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("deviceTypeName")]
        public String DeviceTypeName { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}