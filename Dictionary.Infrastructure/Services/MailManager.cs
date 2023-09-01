using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Services
{
    public class MailManager : IMailManager
    {
        private readonly string _host;
        private readonly string _senderAddress;
        private readonly string _displayName;
        private readonly string _senderPassword;
        private readonly int _port;

        public MailManager(IOptions<MailConfiguaration> mailConfigurationOptions)
        {
            if(mailConfigurationOptions == null)
            {
                throw new ArgumentNullException(nameof(mailConfigurationOptions));
            }

            _host = mailConfigurationOptions.Value.Host;
            _port = mailConfigurationOptions.Value.Port;
            _senderAddress = mailConfigurationOptions.Value.Address;
            _displayName = mailConfigurationOptions.Value.DisplayName;
            _senderPassword = mailConfigurationOptions.Value.Password;
        }

        public async Task<bool> SendAsync(string email, string subject, string body)
        {
                using MailMessage message = new();
                message.To.Add(new MailAddress(email));
                await SendMailAsync(message, subject, body);
                return true;
        }

        public async Task SendMailAsync(MailMessage message, string subject, string body)
        {
            message.From = new MailAddress(_senderAddress, _displayName);

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new(_host, _port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderAddress, _senderPassword),
                EnableSsl = true
            };

            await client.SendMailAsync(message);
        }
    }
}
