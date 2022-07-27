using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailService
    {
        Task Enviar(Contact contact);
    }
    public class EmailServiceSendGrid : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailServiceSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(Contact contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"The client {contact.Email} wants to get in touch with you!";
            var to = new EmailAddress(email, name);
            var planeTextMessage = contact.Message;
            var HtmlContent = $"From: {contact.Name}" +
                              $"Email: {contact.Email}" +
                              $"Message: {contact.Message}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, planeTextMessage, HtmlContent);
            var reply = await client.SendEmailAsync(singleEmail);
        }
    }
}
