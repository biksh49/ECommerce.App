using ECommerce.App.Models;

namespace ECommerce.App.Service
{
    public interface IMailService
    {
         public void SendEmailAsync(MailRequest mailRequest);
    }
}
