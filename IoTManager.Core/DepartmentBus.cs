using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class DepartmentBus:IDepartmentBus
    {
        private readonly IDepartmentDao _departmentDao;

        public DepartmentBus(IDepartmentDao departmentDao)
        {
            this._departmentDao = departmentDao;
        }
    }
}
