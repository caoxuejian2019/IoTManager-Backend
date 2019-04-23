using System;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class CityFormalizer
    {
        public CityFormalizer()
        {
            this.id = 0;
            this.cityName = null;
            this.remark = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
        }

        public CityFormalizer(City city)
        {
            this.id = city.Id;
            this.cityName = city.CityName;
            this.remark = city.Remark;
            this.createTime = city.CreateTime;
            this.updateTime = city.UpdateTime;
        }
        
        public int id { get; set; }
        public String cityName { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}