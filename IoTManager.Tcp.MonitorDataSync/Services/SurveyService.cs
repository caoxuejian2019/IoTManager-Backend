using IoTManager.Tcp.MonitorDataSync.Configure;
using IoTManager.Tcp.MonitorDataSync.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Services
{
    public sealed class SurveyService
    {
        private readonly ILogger<SurveyService> _logger;
        private readonly SockerManager _sockerManager;

        public SurveyService(ILoggerFactory loggerFactory, JobQueue<string> jobQueue)
        {
            this._logger = loggerFactory.CreateLogger<SurveyService>();
            this._sockerManager = new SockerManager(loggerFactory, jobQueue);
        }


        public void SendAcquireMonitorDataCmd(string gatewayIpAddress, int gatewayPort, string nodeAddress, string channel)
        {
            //00 EA 13 A5 01 01 5A
            string command = $"{nodeAddress}{channel}A501015A";
            this._sockerManager.SendCommand(gatewayIpAddress, gatewayPort, command);
        }

        public void SendAcquireGatewayCmd(string gatewayIpAddress, int gatewayPort, string nodeAddress, string channel)
        {
            //00 EA 13 A5 01 02 5A
            string command = $"{nodeAddress}{channel}A501025A";
            this._sockerManager.SendCommand(gatewayIpAddress, gatewayPort, command);
        }

        public void AcquireMonitorData()
        {

        }

        public void AcquireGateway()
        {

        }
    }
}
