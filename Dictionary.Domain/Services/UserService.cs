using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IConfirmationDataService _confirmationDataService;
        private readonly IUserRepository _userRepository;

        public UserService(
            IConfirmationDataService confirmationDataService,
            IUserRepository userRepository)
        {
            _confirmationDataService = confirmationDataService;
            _userRepository = userRepository;
        }

        public void AddUser(AddUserModel model)
        {
            var user = new User(model.Login, model.Password, model.Email);
            _userRepository.Add(user);
        }

        public PasswordRecoveryInfo PasswordRecovery(string email, string confirmationCode, string password)
        {
            var user = _userRepository.List().FirstOrDefault(userSearch => userSearch.Email == email);

            var matchConfirmationCodeInfo = _confirmationDataService.MatchConfirmationCode(email, confirmationCode);

            var canPasswordRecovery = user is not null && matchConfirmationCodeInfo.IsMatch;

            if (canPasswordRecovery)
                UpdatePassword(user,password);

            return new PasswordRecoveryInfo
            {
                MatchConfirmationCodeInfo = matchConfirmationCodeInfo,
                IsPasswordChangeSuccess = canPasswordRecovery
            };
        }

        public void UpdatePassword(User user, string password)
        {
            user.UpdatePassword(password);

            _userRepository.Update(user);
        }

    }
}
