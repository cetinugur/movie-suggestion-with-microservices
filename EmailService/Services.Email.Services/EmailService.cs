using System.Net;
using Services.Email.Model;
using Services.Email.Repositories.Interfaces;
using Services.Email.Services.Events;
using Services.Movie.Client;
using Services.Shared.Authentication.Helper;
using Services.Shared.EventBus;
using Services.Shared.Models;

namespace Services.Email.Services
{
    public class EmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly EmailEvents _emailEvents;
        private readonly HttpContextHelper _httpContextHelper;
        private readonly MovieClient _movieClient;
        public EmailService(IEmailRepository emailRepository,
            EmailEvents emailEvents, HttpContextHelper httpContextHelper, MovieClient movieClient)
        {
            _emailRepository = emailRepository;
            _emailEvents = emailEvents;
            _httpContextHelper = httpContextHelper;
            _movieClient = movieClient;
        }


        public ApiResult EmailRequest()
        {
            try
            {
                var movieSuggestionEmail = new MovieSuggestion()
                {
                    RequestUserId = _httpContextHelper.CurrentUser.Id,
                    RequestDate = DateTime.UtcNow,
                    EmailStatus = EmailStatus.Queued
                };
                _emailRepository.Add(movieSuggestionEmail).SaveChanges();

                var emailRequestEvent = new EmailQueueEvent()
                {
                    // TODO : tamamla
                };

                _emailEvents.SendEmailRequest(emailRequestEvent);
                return new ApiResult(HttpStatusCode.OK, "Email talebi alındı");
            }
            catch (Exception)
            {
                //todo: add logging here
                return new ApiResult(HttpStatusCode.BadRequest, "Email talebiniz alınamadı. Lütfen tekrar deneyiniz.");
            }
        }

        public void SendEmail(Guid emailId)
        { 
            // TODO tamamla
        }
    }
}
