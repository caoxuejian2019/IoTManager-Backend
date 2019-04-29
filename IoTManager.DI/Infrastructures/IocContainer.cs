using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.DI.Infrastructures
{
    public interface IocContainer
    {
        IContainer Build();
        AutofacServiceProvider Injection(IContainer container);
    }
}
