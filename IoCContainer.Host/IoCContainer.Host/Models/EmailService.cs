using IoCContainer.Host.Interfaces;

namespace IoCContainer.Host.Models
{
    public class EmailService : IEmailService
    {

        public EmailService(IEmailClient client)
        {
            Client = client;
        }
            
        public IEmailClient Client { get; set; }

    }
}