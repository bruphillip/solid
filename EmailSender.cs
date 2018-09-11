using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace AulaSolid
{
    public class EmailSender : IEmailSender
    {
        public void Send(string email, string subject, string body)
        {
            var mail = new MailMessage("empresa@empresa.com", email);

            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);
        }
    }
}
