using CleanArchitecture.Core.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace CleanArchitecture.Infrastructure
{
    public class EmailMessageSenderService : IMessageSender
    {
        public void SendNotificationEmail(string toAddress, string messageBody)
        {
            string fromAddress = "mail@mail.com";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Guestbook", fromAddress));
            message.To.Add(new MailboxAddress(toAddress, toAddress));
            message.Subject = "New Message on Guestbook";
            message.Body = new TextPart("Plane")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", 25);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
