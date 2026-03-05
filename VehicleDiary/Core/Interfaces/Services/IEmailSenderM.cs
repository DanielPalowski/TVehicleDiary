namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IEmailSenderM
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
