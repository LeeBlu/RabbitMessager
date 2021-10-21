using System;
using Microsoft.Extensions.DependencyInjection;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider service = new ServiceRegistration().Build();

            var _receivedMessage = service.GetService<IReceiveMessageService>();

             _receivedMessage.ReceiveMessage();

   
        }
    }
}
