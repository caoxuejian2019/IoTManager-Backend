using System;

namespace IoTManager.Model
{
    public class FactoryModel
    {
        public int Id { get; set; }
        public String FactoryName { get; set; }
        public String FactoryPhoneNumber { get; set; }
        public String FactoryAddress { get; set; }
        public String Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public String City { get; set; }
    }
}