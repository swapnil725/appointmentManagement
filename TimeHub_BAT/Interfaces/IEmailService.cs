using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeHub_Modules.Model;

namespace TimeHub_BAT.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(User userData);
        Task<bool> SendEmailAsync(string emailContent);
    }
}
