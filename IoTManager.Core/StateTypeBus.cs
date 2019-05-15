using System;
using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public class StateTypeBus: IStateTypeBus
    {
        private readonly IStateTypeDao _stateTypeDao;
        private readonly ILogger _logger;

        public StateTypeBus(IStateTypeDao stateTypeDao, ILogger<StateTypeBus> logger)
        {
            this._stateTypeDao = stateTypeDao;
            this._logger = logger;
        }
        
        public List<object> GetAllDeviceTypes()
        {
            List<String> deviceTypes = this._stateTypeDao.GetDeviceType();
            List<object> result = new List<object>();
            foreach (String dt in deviceTypes)
            {
                result.Add(new {deviceTypeName = dt});
            }
            return result;
        }

        public List<object> GetAllDeviceStates()
        {
            List<String> deviceStates = this._stateTypeDao.GetDeviceState();
            List<object> result = new List<object>();
            foreach (String ds in deviceStates)
            {
                result.Add(new {stateName = ds});   
            }
            return result;
        }

        public List<object> GetAllGatewayTypes()
        {
            List<String> gatewayTypes = this._stateTypeDao.GetGatewayType();
            List<object> result = new List<object>();
            foreach (String gt in gatewayTypes)
            {
                result.Add(new {gatewayTypeName = gt});
            }
            return result;
        }

        public List<object> GetAllGatewayStates()
        {
            List<String> gatewayStates = this._stateTypeDao.GetGatewayState();
            List<object> result = new List<object>();
            foreach (String gs in gatewayStates)
            {
                result.Add(new {stateName = gs});
            }
            return result;
        }
    }
}