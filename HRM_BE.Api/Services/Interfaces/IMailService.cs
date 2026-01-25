using HRM_BE.Core.Models.Mail;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendMail(SendMailRequest request);
        Task<bool> WorkSendMail(SendMailRequest request);

    }
}
