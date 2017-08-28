using RabbitMQ.Client;
using System.Text;
using System;
using RabbitMQ.Client.Events;

namespace RabbitMqDemo.Bus
{
    public class Bus : IBus
    {
        private const string Exchange = "Demo";

        public void Publish<T>(T @event) where T : IEvent
        {
            throw new NotImplementedException();
        }

        public void Send<T> (T command) where T : ICommand
        {
            var factory = CreateConnectionFactory();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: Exchange, type: "fanout");

                var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(command));

                channel.BasicPublish(exchange: Exchange,
                                    routingKey: "",
                                    basicProperties: null,
                                    body: body);
            }
        }

        private ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = "localhost",
                Port = 32773,
                VirtualHost = "RabbitMqDemo"
            };
        }
    }
}
