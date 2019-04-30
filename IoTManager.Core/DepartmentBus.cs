using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class DepartmentBus:IDepartmentBus
    {
        private readonly IDepartmentDao _departmentDao;
        private readonly ILogger _logger;
        public DepartmentBus(IDepartmentDao departmentDao,ILogger<DepartmentBus> logger)
        {
            this._departmentDao = departmentDao;
            this._logger = logger;
        }
    }
}
