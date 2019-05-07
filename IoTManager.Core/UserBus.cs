using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

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

        public List<UserSerializer> GetAllUsers()
        {
            List<UserModel> users = this._userDao.Get();
            List<UserSerializer> result = new List<UserSerializer>();
            foreach (UserModel user in users)
            {
                result.Add(new UserSerializer(user));
            }
            return result;
        }

        public UserSerializer GetUserById(int id)
        {
            UserModel user = this._userDao.GetById(id);
            UserSerializer result = new UserSerializer(user);
            return result;
        }

        public UserSerializer GetUserByUserName(String userName)
        {
            UserModel user = this._userDao.GetByUserName(userName);
            UserSerializer result = new UserSerializer(user);
            return result;
        }

        public String CreateNewUser(UserSerializer userSerializer)
        {
            UserModel userModel = new UserModel();
            userModel.UserName = userSerializer.userName;
            userModel.DisplayName = userSerializer.displayName;
            userModel.Password = userSerializer.password;
            userModel.Email = userSerializer.email;
            userModel.PhoneNumber = userSerializer.phoneNumber;
            userModel.Remark = userSerializer.remark;
            return this._userDao.Create(userModel);
        }

        public String UpdateUser(int id, UserSerializer userSerializer)
        {
            UserModel userModel = new UserModel();
            userModel.Id = id;
            userModel.UserName = userSerializer.userName;
            userModel.DisplayName = userSerializer.displayName;
            userModel.Password = userSerializer.password;
            userModel.Email = userSerializer.email;
            userModel.PhoneNumber = userSerializer.phoneNumber;
            userModel.Remark = userSerializer.remark;
            return this._userDao.Update(id, userModel);
        }

        public String DeleteUser(int id)
        {
            return this._userDao.Delete(id);
        }
    }
}
