namespace IdentityAppCourse2022.Interfaces
{
    public interface ISendGridEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
