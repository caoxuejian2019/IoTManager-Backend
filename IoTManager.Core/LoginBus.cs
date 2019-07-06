using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Dao;
using IoTManager.IDao;
using IoTManager.Model;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public sealed class LoginBus: ILoginBus
    {
        private readonly IUserDao _userDao;
        private readonly ILogger _logger;

        public LoginBus(IUserDao userDao, ILogger<LoginBus> logger)
        {
            this._userDao = userDao;
            this._logger = logger;
        }
        
        public String Login(LoginModel loginModel)
        {
            UserModel user = this._userDao.GetByUserName(loginModel.Name);
            if (user == null)
            {
                return "Failed";
            } 
            else if (user != null && loginModel.Password != loginModel.Password)
            {
                return "Failed";
            }
            else
            {
                return "success";
            }
        }
    }
}