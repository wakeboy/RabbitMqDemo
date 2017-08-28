using RabbitMqDemo.Bus;
using System;

namespace RabbitMqDemo.Bus.Commands
{
    public class AddUser : ICommand
    {
        /// <summary>
        /// The name of the user to add
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The users data of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
