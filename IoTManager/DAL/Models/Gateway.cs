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
        public int GatewayTypeId { get; set; }
        [ForeignKey("GatewayTypeId")]
        public GatewayType GatewayType { get; set; }
        
        
        [Column("city")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        
        
        [Column("factory")]
        public int FactoryId { get; set; }
        [ForeignKey("FactoryId")]
        public Factory Factory { get; set; }
        
        
        [Column("workshop")]
        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set; }
        
        
        [Column("gatewayState")]
        public int GatewayStateId { get; set; }
        [ForeignKey("GatewayStateId")]
        public GatewayState GatewayState { get; set; }
        
        
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
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}