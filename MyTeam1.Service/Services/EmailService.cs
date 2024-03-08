using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using MyTeam_1.Interface;
using MyTeam_1.Models;
using System.Net;
using System.Net.Mail;

public class EmailService  : IEmailService
{
    #region DI
    private readonly SmtpClient _smtpClient;
    private readonly IConfiguration _configuration;
    
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    #region SendEmail
    public async Task SendEmailAsync( string senderEmail,string receiverEmail, string subject, string body)
    {
        string _smtpServer = _configuration["SmtpSettings:Server"];
        int _smtpPort = int.Parse( _configuration["SmtpSettings:Port"]);
        string _smtpUsername = _configuration["SmtpSettings:Username"];
        string _smtpPassword = _configuration["SmtpSettings:Password"];


        using (SmtpClient client = new SmtpClient(_smtpServer, _smtpPort))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            client.EnableSsl = true;

            var message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            try
            {
                await client.SendMailAsync(message);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
                throw;
            }
        }
    }
    #endregion
}
