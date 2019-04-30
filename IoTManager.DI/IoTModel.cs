using Autofac;
using IoTManager.Core;
using IoTManager.Core.Infrastructures;
using IoTManager.Dao;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.DI
{
    internal sealed class IoTPlatformModel:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //IoTManager.Core
            builder.RegisterType<CityBus>().As<ICityBus>();
            builder.RegisterType<DepartmentBus>().As<IDepartmentBus>();
            builder.RegisterType<DeviceBus>().As<IDeviceBus>();
            builder.RegisterType<GatewayBus>().As<IGatewayBus>();
            builder.RegisterType<RoleBus>().As<IRoleBus>();
            builder.RegisterType<UserBus>().As<IUserBus>();
            //IoTManager.Dao
            builder.RegisterType<CityDao>().As<ICityDao>();
            builder.RegisterType<DepartmentDao>().As<IDepartmentDao>();
            builder.RegisterType<DeviceDao>().As<IDeviceDao>();
            builder.RegisterType<GatewayDao>().As<IGatewayDao>();
            //base.Load(builder);
        }
    }
}
