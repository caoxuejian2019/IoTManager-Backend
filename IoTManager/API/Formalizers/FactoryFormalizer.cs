using System;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class FactoryFormalizer
    {
        public FactoryFormalizer()
        {
            this.id = 0;
            this.factoryName = null;
            this.factoryPhoneNumber = null;
            this.factoryAddress = null;
            this.remark = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
            this.city = null;
        }

        public FactoryFormalizer(Factory factory)
        {
            this.id = factory.Id;
            this.factoryName = factory.FactoryName;
            this.factoryPhoneNumber = factory.FactoryPhoneNumber;
            this.factoryAddress = factory.FactoryAddress;
            this.remark = factory.Remark;
            this.createTime = factory.CreateTime;
            this.updateTime = factory.UpdateTime;
            this.city = factory.City.CityName;
        }
        
        public int id { get; set; }
        public String factoryName { get; set; }
        public String factoryPhoneNumber { get; set; }
        public String factoryAddress { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String city { get; set; }
    }
}