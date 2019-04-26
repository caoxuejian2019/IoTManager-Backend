using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTManager.DAL.Models
{
    public class GatewayState
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("stateName")]
        public String StateName { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}