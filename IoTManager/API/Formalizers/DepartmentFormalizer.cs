using System;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class DepartmentFormalizer
    {
        public DepartmentFormalizer()
        {
            this.id = 0;
            this.path = null;
            this.departmentName = null;
            this.phoneNumber = null;
            this.remark = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
        }

        public DepartmentFormalizer(Department department)
        {
            this.id = department.Id;
            this.path = department.Path;
            this.departmentName = department.DepartmentName;
            this.phoneNumber = department.PhoneNumber;
            this.remark = department.Remark;
            this.createTime = department.CreateTime;
            this.updateTime = department.UpdateTime;
        }
        
        public int id { get; set; }
        public String path { get; set; }
        public String departmentName { get; set; }
        public String phoneNumber { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}