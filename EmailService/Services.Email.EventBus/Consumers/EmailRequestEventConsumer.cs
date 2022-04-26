using MassTransit;
using Services.Email.Services;
using Services.Shared.EventBus;

namespace Services.Email.EventBus.Consumers
{
    public class EmailRequestEventConsumer : IConsumer<EmailQueueEvent>
    {
        private readonly EmailService _emailService;

        public EmailRequestEventConsumer(EmailService emailService)
        {
            _emailService = emailService;
        }

        public Task Consume(ConsumeContext<EmailQueueEvent> context)
        {
            _emailService.SendEmail(context.Message.EmailId);
            return Task.CompletedTask;
        }
    }
}
