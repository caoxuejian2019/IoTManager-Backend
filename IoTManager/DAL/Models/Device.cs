using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IoTManager.DAL.Models
{
    public class Device
    {
        public int id { get; set; }
        public String hardwareDeviceID { get; set; }
        public String deviceName { get; set; }
        
        
        [Column("city")]
        public int cityId { get; set; }
        [ForeignKey("cityId")]
        public City city { get; set; }
        
        
        [Column("factory")]
        public int factoryId { get; set; }
        [ForeignKey("factoryId")]
        public Factory factory { get; set; }
        
        
        [Column("workshop")]
        public int workshopId { get; set; }
        [ForeignKey("workshopId")]
        public Workshop workshop { get; set; }
        
        
        [Column("deviceState")]
        public int deviceStateId { get; set; }
        [ForeignKey("deviceStateId")]
        public DeviceState deviceState { get; set; }
        
        
        public DateTime LastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public int gatewayID { get; set; }
        public String mac { get; set; }
        
        
        [Column("deviceType")]
        public int deviceTypeId { get; set; }
        [ForeignKey("deviceTypeId")]
        public DeviceType deviceType { get; set; }
        
        
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        
        
        [Column("department")]
        public int departmentId { get; set; }
        [ForeignKey("departmentId")]
        public Department department { get; set; }
    }
}