using Dictionary.Domain.Data.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Services.Contracts
{
    public interface IConfirmationDataService
    {
        Task<bool> SendConfirmationCodeByEmailAsync(string email);
        MatchConfirmationCodeInfo MatchConfirmationCode(string email, string confirmationCode);

    }
}
