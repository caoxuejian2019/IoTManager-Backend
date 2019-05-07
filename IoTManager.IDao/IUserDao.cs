using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IUserDao
    {
        String Create(UserModel userModel);
        List<UserModel> Get();
        UserModel GetById(int id);
        UserModel GetByUserName(String userName);
        String Update(int id, UserModel userModel);
        String Delete(int id);
    }
}
