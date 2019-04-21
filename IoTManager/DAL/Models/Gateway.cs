using System;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

namespace IoTManager.DAL.Models
{
    public class Gateway
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("hardwareGatewayID")]
        public String HardwareGatewayId { get; set; }
        
        
        [Column("gatewayName")]
        public String GatewayName { get; set; }
        
        
        [Column("gatewayType")]
        public int GatewayType { get; set; }
        
        
        [Column("city")]
        public int City { get; set; }
        
        
        [Column("factory")]
        public int Factory { get; set; }
        
        
        [Column("workshop")]
        public int Workshop { get; set; }
        
        
        [Column("gatewayState")]
        public int GatewayState { get; set; }
        
        
        [Column("lastConnectionTime")]
        public DateTime LastConnectionTime { get; set; }
        
        
        [Column("imageUrl")]
        public String ImageUrl { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("department")]
        public int Department { get; set; }
    }
}