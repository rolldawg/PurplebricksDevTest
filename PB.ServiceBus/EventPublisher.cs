using System.Threading.Tasks;

namespace PB.ServiceBus
{
    // Please do not change
    public class EventPublisher : IEventPublisher
    {
		/*
		 *  Do not change!
		 *
		 **/
        public async Task PublishEvent<T>(T @event)
        {
            await Task.Delay(50);
        }
    }
}