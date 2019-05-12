using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class GatewayModel
    {
        public int Id { get; set; }
        public String HardwareGatewayId { get; set; }
        public String GatewayName { get; set; }
        public String City { get; set; }
        public String Factory { get; set; }
        public String Workshop { get; set; }
        public String GatewayType { get; set; }
        public String GatewayState { get; set; }
        public String ImageUrl { get; set; }
        public String Remark { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
