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

        public AutofacServiceProvider Injection()
        {
            return new AutofacServiceProvider(this._container);
        }
    }
}
