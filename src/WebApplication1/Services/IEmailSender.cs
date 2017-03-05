using System.Threading.Tasks;

namespace coreenginex.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}