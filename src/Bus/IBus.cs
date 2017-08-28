using System;

namespace RabbitMqDemo.Bus
{
    public interface IBus
    {
        void Send<T>(T command) where T : ICommand;

        void Publish<T>(T @event) where T : IEvent;
    }
}
