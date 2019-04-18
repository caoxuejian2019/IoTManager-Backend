using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IoTManager.DAL.Models
{
    public class Device
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("hardwareDeviceID")]
        public String HardwareDeviceId { get; set; }
        
        
        [Column("deviceName")]
        public String DeviceName { get; set; }
        
        
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
        
        
        [Column("deviceState")]
        public int DeviceStateId { get; set; }
        [ForeignKey("DeviceStateId")]
        public DeviceState DeviceState { get; set; }
        
        
        [Column("LastConnectionTime")]
        public DateTime LastConnectionTime { get; set; }
        
        
        [Column("imageUrl")]
        public String ImageUrl { get; set; }
        
        
        [Column("gatewayID")]
        public int GatewayId { get; set; }
        
        
        [Column("mac")]
        public String Mac { get; set; }
        
        
        [Column("deviceType")]
        public int DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public DeviceType DeviceType { get; set; }
        
        
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