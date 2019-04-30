using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class UserBus:IUserBus
    {
        private readonly IUserDao _userDao;
        private readonly ILogger _logger;
        public UserBus(IUserDao userDao,ILogger<UserBus> logger)
        {
            this._userDao = userDao;
            this._logger = logger;
        }
    }
}
