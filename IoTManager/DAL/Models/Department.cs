using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTManager.DAL.Models
{
    public class Department
    {
        [Column("id")]
        public int Id { get; set; }
        
        
        [Column("path")]
        public String Path { get; set; }
        
        
        [Column("departmentName")]
        public String DepartmentName { get; set; }
        
        
        [Column("phoneNumber")]
        public String PhoneNumber { get; set; }
        
        
        [Column("remark")]
        public String Remark { get; set; }
        
        
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
        
        
        [Column("updateTime")]
        public DateTime UpdateTime { get; set; }
    }
}