namespace MyTeam_1.Interface
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string senderEmail, string receiverEmail, string subject, string body);
    }
}
