using System;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI.Relational;

namespace IoTManager.DAL.Models
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("userName")]
        public String UserName { get; set; }
        
        
        [Column("displayName")]
        public String DisplayName { get; set; }
        
        
        [Column("password")]
        public String Password { get; set; }
        
        
        [Column("email")]
        public String Email { get; set; }
        
        
        [Column("phoneNumber")]
        public String PhoneNumber { get; set; }
        
        
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