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
        
        public List<String> GetAllDeviceTypes()
        {
            return this._stateTypeDao.GetDeviceType();
        }

        public List<String> GetAllDeviceStates()
        {
            return this._stateTypeDao.GetDeviceState();
        }

        public List<String> GetAllGatewayTypes()
        {
            return this._stateTypeDao.GetGatewayType();
        }

        public List<String> GetAllGatewayStates()
        {
            return this._stateTypeDao.GetGatewayState();
        }
    }
}