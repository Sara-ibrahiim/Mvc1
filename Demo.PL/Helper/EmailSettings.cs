using Demo.DAL.Enitities;
using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helper
{
    public class EmailSettings
    { 
        public static void SendEmail (Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("sou.cute94@gmail.com", "mksfeuasiheyyxkg");
            client.Send("sou.cute94@gmail.com", email.To, email.Title, email.Body);
        }
    }
}
