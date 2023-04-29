using System.Net;
using System.Net.Mail;

namespace eFitnessAPI.Services
{
    public class MailService : IMailService
    {
        public bool Posalji(string to, string message, string subject)
        {
            var key = "ovmogyemxnryjfcm";

            var sendMailFrom = "efitnessrs1@gmail.com";
            var sendMailTo = to;
            var mailSubject = subject;
            var mailBody = message;

            var smtpServer = new SmtpClient("smtp.gmail.com", 587);
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            var email = new MailMessage();
            email.From = new MailAddress(sendMailFrom);
            email.To.Add(sendMailTo);
            email.CC.Add(sendMailFrom);
            email.Subject = mailSubject;
            email.Body = mailBody;
            email.IsBodyHtml = true;

            smtpServer.Timeout = 5000;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(sendMailFrom, key);
            smtpServer.Send(email);

            return true;
        }
    }
}
