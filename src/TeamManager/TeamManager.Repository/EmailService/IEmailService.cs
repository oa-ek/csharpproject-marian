using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Repository.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string htmlMessage);
    }

}
