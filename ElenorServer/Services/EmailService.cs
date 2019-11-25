using System.Net.Mail;
using System.Net.Http;
using Contracts;
using Entities.Models;
using System;

namespace Services
{
    public class EmailService : IEmailService
    {
        //protected HttpClient httpClient { get; }
        private ILoggerManager _logger;

        public EmailService(ILoggerManager logger)
        {
            //httpClient = new HttpClient();
            this._logger = logger;
        }

        public void SendMessage(Message message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(message.Email);
            mail.To.Add("chrisrudnicky@gmail.com");
            mail.Subject = message.Subject;
            mail.Body = message.Note;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("68thandMaine", "Sequ01@68");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}





