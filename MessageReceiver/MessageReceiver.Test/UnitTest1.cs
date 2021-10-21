using NUnit.Framework;
using System;
using Microsoft.Extensions.DependencyInjection;
using MessageProducer;

namespace MessageReceiver.Test
{
    public class Tests
    {
        [Test]
        public void Vaild_message_received()
        {
            //Arrange
            IServiceProvider service = new ServiceRegistration().Build();
            IServiceProvider service2 = new MessageProducer.ServiceRegistration().Build();
            var _produceMessage = service2.GetService<IProduceMessageService>();
             _produceMessage.SendMessage("peter");
            var _receiveMessage = service.GetService<IReceiveMessageService>();

            //Act
            string received = _receiveMessage.ReceiveMessage();
            //Assert
            Assert.IsNotEmpty(received);
        }

        [Test]
        public void Invaild_message_received()
        {
            //Arrange
            IServiceProvider service = new ServiceRegistration().Build();
            var _produceMessage = service.GetService<IReceiveMessageService>();

            //Act
            string received = _produceMessage.ReceiveMessage();
            //Assert
            Assert.IsEmpty(received);
        }
    }
}