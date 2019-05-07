using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class DeviceModel
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
        public DeviceAuthentication Authentication { get; set; }
        public DeviceCapabilities Capabilities { get; set; }
    }

    public sealed class DeviceAuthentication
    {
        public Symmetrickey SymmetricKey { get; set; }
        public X509thumbprint X509Thumbprint { get; set; }
        public string Type { get; set; }
    }

    public sealed class Symmetrickey
    {
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
    }

    public sealed class X509thumbprint
    {
        public object PrimaryThumbprint { get; set; }
        public object SecondaryThumbprint { get; set; }
    }

    public sealed class DeviceCapabilities
    {
        public bool IotEdge { get; set; }
    }

}
