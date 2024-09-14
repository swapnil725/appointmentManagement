using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimeHub_BAT.Interfaces;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Services
{
    public class EmailService : IEmailService
    {
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "yadavrajkesh9923@gmail.com"; //Sender Email Address  
        static string password = "Rvtech@7043"; //Sender Password  
        static string emailToAddress = "yadavrajkesh8999@gmail.com"; //Receiver Email Address  
        static string subject = "Test from SMTP";
        static string body = "Hello, This is Email sending test using gmail.";
        static void Main(string[] args)
        {
            SendEmail();
        }
        public static void SendEmail()
        {

        }
        public async Task<bool> SendEmailAsync(User userData)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(emailToAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<bool> SendEmailAsync(string emailContent)
        {
            throw new NotImplementedException();
        }
    }
}
