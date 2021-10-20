using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MessageProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider service = new ServiceRegistration().Build();

            var _produceMessage = service.GetService<IProduceMessageService>();
  
            string name = "";
            Console.WriteLine("enter name ");
            name = Console.ReadLine();
            Console.WriteLine("Hello my name is,{0}", name);
            _produceMessage.SendMessage(name);
        }
    }
}
