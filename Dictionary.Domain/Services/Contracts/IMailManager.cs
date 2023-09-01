using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Services.Contracts
{
    public interface IMailManager
    {
        /// <summary>
        ///     Отправка письма на почту.
        /// </summary>
        Task<bool> SendAsync(string email, string subject, string body);
    }
}
