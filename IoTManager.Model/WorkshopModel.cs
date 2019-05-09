using System;

namespace IoTManager.Model
{
    public class WorkshopModel
    {
        public int Id { get; set; }
        public String WorkshopName { get; set; }
        public String WorkshopPhoneNumber { get; set; }
        public String WorkshopAddress { get; set; }
        public String Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public String Factory { get; set; }
    }
}