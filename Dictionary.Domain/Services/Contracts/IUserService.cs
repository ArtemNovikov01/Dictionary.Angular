using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Services.Contracts
{
    public interface IUserService
    {
        void AddUser(AddUserModel model);
        PasswordRecoveryInfo PasswordRecovery(string email, string confirmationCode, string password);

    }
}
