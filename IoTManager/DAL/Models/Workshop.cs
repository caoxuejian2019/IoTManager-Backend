using System;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

namespace IoTManager.DAL.Models
{
    public class Workshop
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("workshopName")]
        public String WorkshopName { get; set; }
        
        
        [Column("workshopPhoneNumber")]
        public String WorkshopPhoneNumber { get; set; }
        
        
        [Column("workshopAddress")]
        public String WorkshopAddress { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
        
        
        [Column("factory")]
        public int FactoryId { get; set; }
        [Column("FactoryId")]
        public Factory Factory { get; set; }
    }
}