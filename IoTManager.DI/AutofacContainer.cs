using Autofac;
using Autofac.Extensions.DependencyInjection;
using IoTManager.DI.Infrastructures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.DI
{
    public sealed class AutofacContainer : IocContainer
    {
        private readonly IServiceCollection _services;
        private IContainer _container;

        public AutofacContainer(IServiceCollection services)
        {
            if (services == null)
            {
                throw new NullReferenceException();
            }
            this._services = services;
        }

        public IocContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IoTPlatformModel>();
            builder.Populate(this._services);
            this._container = builder.Build();
            return this;
        }

        public AutofacServiceProvider FetchServiceProvider()
        {
            if (this._container == null)
            {
                throw new Exception("you need call Build() to initial the Ioc Container before");
            }
            return new AutofacServiceProvider(this._container);
        }
    }
}
