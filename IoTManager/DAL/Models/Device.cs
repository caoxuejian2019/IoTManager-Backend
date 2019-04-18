using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IoTManager.DAL.Models
{
    public class Device
    {
        public int? id { get; set; }
        public String hardwareDeviceID { get; set; }
        public String deviceName { get; set; }
        
        
        [Column("city")]
        public int? city_id { get; set; }
        [ForeignKey("city_id")]
        public City City { get; set; }
        
        
        [Column("factory")]
        public int? factory_id { get; set; }
        [ForeignKey("factory_id")]
        public Factory factory { get; set; }
        
        
        [Column("workshop")]
        public int? workshop_id { get; set; }
        [ForeignKey("workshop_id")]
        public Workshop workshop { get; set; }
        
        
        [Column("deviceState")]
        public int? deviceState_id { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public int? gatewayID { get; set; }
        public String mac { get; set; }
        public int? deviceType { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
        public String remark { get; set; }
        public int? department { get; set; }
    }
}