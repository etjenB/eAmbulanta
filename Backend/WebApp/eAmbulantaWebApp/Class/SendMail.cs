using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace eAmbulantaWebApp.Class
{
    public static class SendMail
    {

        //Slanje maila funkcija -----------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SendEmail(string Subject, string Text, string ImePrezime, string Mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("eAmbulanta", "eambulantaonline@outlook.com"));
            message.To.Add(new MailboxAddress(ImePrezime, Mail));
            message.Subject = Subject;
            message.Body = new TextPart("plain")
            {
                Text = Text
            };

            var client = new SmtpClient();
            client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("eambulantaonline@outlook.com", "eambulanta123");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
