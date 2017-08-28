using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMqDemo.Consumer2
{
    class Program
    {
        private const string Queue = "Consumer2";
        private const string Exchange = "Demo";

        static void Main(string[] args)
        {
            Console.Title = $"Rabbit {Queue}";

            var factory = CreateConnectionFactory();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                DeclareExchange(channel);
                DeclareQueue(channel);

                channel.QueueBind(queue: Queue,
                                  exchange: Exchange,
                                  routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };

                channel.BasicConsume(queue: Queue,
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadKey();
            }
        }

        private static ConnectionFactory CreateConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = "localhost",
                Port = 32773,
                VirtualHost = "RabbitMqDemo"
            };
        }

        private static void DeclareExchange(IModel channel)
        {
            channel.ExchangeDeclare(exchange: Exchange,
                                    type: "fanout");
        }

        private static void DeclareQueue(IModel channel)
        {

            channel.QueueDeclare(queue: Queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
    }
}