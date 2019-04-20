using System;

namespace IoTManager.DAL.Models
{
    public class Workshop
    {
        public int id { get; set; }
        public String workshopName { get; set; }
        public String workshopPhoneNumber { get; set; }
        public String workshopAddress { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}