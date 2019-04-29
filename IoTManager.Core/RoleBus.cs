using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class RoleBus:IRoleBus
    {
        private readonly IRoleDao _roleDao;

        public RoleBus(IRoleDao roleDao)
        {
            this._roleDao = roleDao;
        }
    }
}
