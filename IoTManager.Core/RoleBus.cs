using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class RoleBus:IRoleBus
    {
        private readonly IRoleDao _roleDao;
        private readonly ILogger _logger;
        public RoleBus(IRoleDao roleDao,ILogger<RoleBus> logger)
        {
            this._roleDao = roleDao;
            this._logger = logger;
        }
    }
}
