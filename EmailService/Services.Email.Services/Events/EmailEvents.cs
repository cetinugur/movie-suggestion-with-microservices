using MassTransit;
using Services.Shared.EventBus;

namespace Services.Email.Services.Events
{
    public class EmailEvents
    {
        private readonly IPublishEndpoint _publishEndPoint;
        public EmailEvents(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }

        public void SendEmailRequest(EmailQueueEvent @event)
        {
            _publishEndPoint.Publish(@event);
        }
    }
}
