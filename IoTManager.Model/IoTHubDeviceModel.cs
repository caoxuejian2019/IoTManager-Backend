using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class IoTHubDeviceModel
    {
        public string DeviceId { get; set; }
        public string GenerationId { get; set; }
        public string Etag { get; set; }
        public string ConnectionState { get; set; }
        public string Status { get; set; }
        public object StatusReason { get; set; }
        public DateTime ConnectionStateUpdatedTime { get; set; }
        public DateTime StatusUpdatedTime { get; set; }
        public DateTime LastActivityTime { get; set; }
        public int CloudToDeviceMessageCount { get; set; }
        public Authentication Authentication { get; set; }
        public Capabilities Capabilities { get; set; }
    }

    public class Authentication
    {
        public Symmetrickey SymmetricKey { get; set; }
        public X509thumbprint X509Thumbprint { get; set; }
        public string Type { get; set; }
    }

    public class Symmetrickey
    {
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
    }

    public class X509thumbprint
    {
        public object PrimaryThumbprint { get; set; }
        public object SecondaryThumbprint { get; set; }
    }

    public class Capabilities
    {
        public bool IotEdge { get; set; }
    }

}
