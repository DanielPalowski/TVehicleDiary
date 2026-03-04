namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
