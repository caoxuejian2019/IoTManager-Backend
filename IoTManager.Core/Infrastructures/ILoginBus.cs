using System;
using IoTManager.Model;

namespace IoTManager.Core.Infrastructures
{
    public interface ILoginBus
    {
        String Login(LoginModel loginModel);
    }
}