using Autofac;
using IoTManager.AzureIoTHub;
using IoTManager.Core;
using IoTManager.Core.Infrastructures;
using IoTManager.Dao;
using IoTManager.IDao;
using IoTManager.IHub;
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
            builder.RegisterType<FactoryBus>().As<IFactoryBus>();
            builder.RegisterType<WorkshopBus>().As<IWorkshopBus>();
            builder.RegisterType<StateTypeBus>().As<IStateTypeBus>();
            builder.RegisterType<DeviceDataBus>().As<IDeviceDataBus>();
            builder.RegisterType<AlarmInfoBus>().As<IAlarmInfoBus>();
            //IoTManager.Dao
            builder.RegisterType<CityDao>().As<ICityDao>();
            builder.RegisterType<DepartmentDao>().As<IDepartmentDao>();
            builder.RegisterType<DeviceDao>().As<IDeviceDao>();
            builder.RegisterType<GatewayDao>().As<IGatewayDao>();
            builder.RegisterType<UserDao>().As<IUserDao>();
            builder.RegisterType<FactoryDao>().As<IFactoryDao>();
            builder.RegisterType<WorkshopDao>().As<IWorkshopDao>();
            builder.RegisterType<StateTypeDao>().As<IStateTypeDao>();
            builder.RegisterType<DeviceDataDao>().As<IDeviceDataDao>();
            builder.RegisterType<AlarmInfoDao>().As<IAlarmInfoDao>();
            //IoTManager.AzureIoTHub
            builder.RegisterType<AzureIoTHub.AzureIoTHub>().As<IoTHub>();
            //base.Load(builder);
        }
    }
}
