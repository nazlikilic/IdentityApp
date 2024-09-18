namespace IdentityApp.Models
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);//email konnu ve mesaj içerikli olacak.
    }
}