using System;

namespace IoTManager.DAL.Models
{
    public class PageElement
    {
        public int? id { get; set; }
        public String pageElementName { get; set; }
        public String remark { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}