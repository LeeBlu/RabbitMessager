using NUnit.Framework;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MessageProducer.Test
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Vaild_sent_message()
        {
            //Arrange
            IServiceProvider service = new ServiceRegistration().Build();
            var _produceMessage = service.GetService<IProduceMessageService>();

            //Act
            bool sent= _produceMessage.SendMessage("peter");
            //Assert
            Assert.IsTrue(sent);
        }
        [Test]
        public void Invaild_sent_message()
        {
            //Arrange
            IServiceProvider service = new ServiceRegistration().Build();
            var _produceMessage = service.GetService<IProduceMessageService>();

            //Act
            bool sent = _produceMessage.SendMessage("");
            //Assert
            Assert.IsFalse(sent);
        }
    }
}