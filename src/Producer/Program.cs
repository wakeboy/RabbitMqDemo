using RabbitMqDemo.Bus;
using RabbitMqDemo.Bus.Commands;
using System;
using System.Threading;

namespace RabbitMqDemo.Producer
{
    using Bus = RabbitMqDemo.Bus.Bus;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rabbit Producer";

            string name = string.Empty;
            do
            {
                Console.Write("Enter UserName: ");
                name = Console.ReadLine();

                Thread.Sleep(100);

                ICommand user = CreateUser(name);
                IBus bus = new Bus();
                bus.Send(user);

                Console.WriteLine($"Sending Add User {name}");

            } while (name != "exit");

            Console.WriteLine("Finished Sending Commands");
            Console.ReadKey();
        }

        private static AddUser CreateUser(string name)
        {
            return new AddUser
            {
                Name = name,
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "123456789"
            };
        }
    }
}