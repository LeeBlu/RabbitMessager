using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver
{
    public class MessagerChannel : IMessagerChannel
    {
        private ConnectionFactory _ConnectionFactory = new ConnectionFactory();
        public string SetUp()
        {
            string receivedMessage = "";
            try
            {
              
                var factory = _ConnectionFactory.HostName = "localhost";

                using (var connection = _ConnectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Messager"
                                        , durable: true
                                        , exclusive: false
                                        , autoDelete: false
                                        , arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var _body = ea.Body;
                        var message = Encoding.UTF8.GetString(_body.ToArray());
                        receivedMessage = $"Msg Received {message}";
                    };
                    channel.BasicConsume("Messager", autoAck: true, consumer: consumer);
                }
                return receivedMessage;
            }
            catch (Exception ex)
            {

                return receivedMessage = "";
            }

        }
    }
}
