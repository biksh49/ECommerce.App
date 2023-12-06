using ECommerce.App.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ECommerce.App.Service
{
    public class MailService : IMailService
    {
       
        private readonly MailSettings _mailSettings;
        //public MailService(IOptions<MailSettings> mailSettings)
        //{
        //    _mailSettings = mailSettings.Value;
        //}
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

    //    public void SendEmailAsync(MailRequest mailRequest)
    //    {
    //        try
    //        {
    //            var email = new MimeMessage();
    //            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
    //            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
    //            email.Subject = mailRequest.Subject;
    //            var builder = new BodyBuilder();
    //            #region attachmentFlow
    //            if (mailRequest.Attachments != null)
    //            {
    //                byte[] fileBytes;
    //                foreach (var file in mailRequest.Attachments)
    //                {
    //                    if (file.Length > 0)
    //                    {
    //                        using (var ms = new MemoryStream())
    //                        {
    //                            file.CopyTo(ms);
    //                            fileBytes = ms.ToArray();
    //                        }
    //                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
    //                    }
    //                }
    //            }
    //            #endregion
    //            builder.HtmlBody = mailRequest.Body;
    //            email.Body = builder.ToMessageBody();
    //            using var smtp = new SmtpClient();
    //            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
    //            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
    //            smtp.SendAsync(email);
    //            smtp.Disconnect(true);
    //        }

    //        catch (Exception ex)
    //        {

    //            throw;
    //        }
    //    }

    //}

    public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();

                #region attachmentFlow
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                #endregion

                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }




    }
}

