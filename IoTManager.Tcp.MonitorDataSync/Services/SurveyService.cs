using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Services
{
    public sealed class SurveyService
    {
        private readonly SockerManager _sockerManager;
        private readonly string _gatewayIpAddress;
        private readonly string _gatewayPort;
        private readonly string _nodeAddress;
        private readonly string _channel;

        public SurveyService(string gatewayIpAddress,string gatewayPort,string nodeAddress,string channel)
        {
            this._sockerManager = new SockerManager();
            this._gatewayIpAddress = gatewayIpAddress;
            this._gatewayPort = gatewayPort;
            this._nodeAddress = nodeAddress;
            this._channel = channel;
        }

        public void SendAcquireMonitorDataCmd()
        {
            //00 EA 13 A5 01 01 5A
            string command = $"{this._nodeAddress}{this._channel}A501015A";
            this._sockerManager.SendCommand(this._gatewayIpAddress, this._gatewayPort, command);
        }

        public void AcquireMonitorData()
        {
            
        }

        public void AcquireGateway()
        {
            string command = $"{this._nodeAddress}{this._channel}A501025A";
            this._sockerManager.SendCommand(this._gatewayIpAddress, this._gatewayPort, command);
        }
    }
}
