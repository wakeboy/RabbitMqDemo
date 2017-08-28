namespace RabbitMqDemo.Bus.Events
{
    public class UserAdded : IEvent
    {
        /// <summary>
        /// Id of the user added
        /// </summary>
        public int Id { get; internal set; }
    }
}
