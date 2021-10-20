using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver
{
    public class ServiceRegistration
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();
            container.AddScoped<IReceiveMessageService, ReceiveMessageService>();
            container.AddScoped<IMessagerChannel, MessagerChannel>();
            return container.BuildServiceProvider();
        }
    }
}
