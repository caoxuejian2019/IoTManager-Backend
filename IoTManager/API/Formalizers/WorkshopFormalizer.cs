using System;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class WorkshopFormalizer
    {
        public WorkshopFormalizer()
        {
            this.id = 0;
            this.workshopName = null;
            this.workshopPhoneNumber = null;
            this.workshopAddress = null;
            this.remark = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
            this.factory = null;
        }

        public WorkshopFormalizer(Workshop workshop)
        {
            this.id = workshop.Id;
            this.workshopName = workshop.WorkshopName;
            this.workshopPhoneNumber = workshop.WorkshopPhoneNumber;
            this.workshopAddress = workshop.WorkshopAddress;
            this.remark = workshop.Remark;
            this.createTime = workshop.CreateTime;
            this.updateTime = workshop.UpdateTime;
            this.factory = workshop.Factory.FactoryName;
        }
        
        public int id { get; set; }
        public String workshopName { get; set; }
        public String workshopPhoneNumber { get; set; }
        public String workshopAddress { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String factory { get; set; }
    }
}