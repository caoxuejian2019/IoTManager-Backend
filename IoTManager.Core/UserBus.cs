using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class UserBus:IUserBus
    {
        private readonly IUserDao _userDao;
        public UserBus(IUserDao userDao)
        {
            this._userDao = userDao;
        }
    }
}
