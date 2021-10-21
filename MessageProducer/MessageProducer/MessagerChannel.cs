using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProducer
{
    class MessagerChannel : IMessagerChannel
    {
        private ConnectionFactory _ConnectionFactory = new ConnectionFactory();
        public MessagerChannel()
        {

        }

        public bool SetUp(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    return false;
                }
                var factory = _ConnectionFactory.HostName = "localhost";

                using (var connection = _ConnectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Messager"
                                        , durable: true
                                        , exclusive: false
                                        , autoDelete: false
                                        , arguments: null);


                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "Messager",
                                         basicProperties: null,
                                         body: body);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }
    }
}
