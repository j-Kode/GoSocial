using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace GoSocial.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            //GMAIL SENDING OPTION
            //var mimeMessage = new MimeMessage();
            //mimeMessage.From.Add(new MailboxAddress("Jeff", "Sidhujeffery@gmail.com"));
            //mimeMessage.To.Add(new MailboxAddress("New User", email));
            //mimeMessage.Subject = subject;
            //mimeMessage.Body = new TextPart("plain")
            //{
            //    Text = message
            //};

            //var client = new SmtpClient();

            //client.Connect("smtp.gmail.com", 587, false);
            //client.Authenticate(new NetworkCredential("sidhujeffery@gmail.com", password));
            //// Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
            //return client.SendAsync(mimeMessage);



            //SENDGRID COMMENTED CODE BELOW
            var myMessage = new SendGrid.SendGridMessage();
            myMessage.AddTo(email);
            myMessage.From = new System.Net.Mail.MailAddress("sidhujeffery@gmail.com", "Jeff Sidhu");
            myMessage.Subject = subject;
            myMessage.Text = message;
            myMessage.Html = message;
            //var credentials = new System.Net.NetworkCredential(
            //    Options.SendGridUser,
            //    Options.SendGridKey);
            // Create a Web transport for sending email.
            var transportWeb = new SendGrid.Web(Options.SendGridKey);
            return transportWeb.DeliverAsync(myMessage);
        }

        public Task SendSmsAsync(string number, string message)
        {
            //Plug in your SMS service here to send a text message.
           TwilioClient.Init(Options.SID, Options.AuthToken);
            var twilio = new TwilioRestClient(
            Options.SID,           // Account Sid from dashboard
            Options.AuthToken);    // Auth Token
            var smsMessage = new MessageCreator(Options.SID, new PhoneNumber(number), new PhoneNumber(Options.SendNumber), message).ExecuteAsync(twilio);
            return Task.FromResult(0);

        }

    }
}
