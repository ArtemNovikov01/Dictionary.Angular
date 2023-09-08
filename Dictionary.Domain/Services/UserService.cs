using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Entity.Enum;
using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Domain.Exception;
using Dictionary.Domain.Services.Contracts;
using Serilog;
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
        //private readonly ILogger _logger;

        public UserService(
            IConfirmationDataService confirmationDataService,
            IUserRepository userRepository)
            //,ILogger logger)
        {
            _confirmationDataService = confirmationDataService;
            _userRepository = userRepository;
            //_logger = logger;
        }

        public void AddUser(AddUserModel model)
        {
            var user = new User(model.Login, model.Password, model.Email);
            CheckOtherDesignerInOrganization(model.Login);
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

        private void CheckOtherDesignerInOrganization(string login)
        {
                if (_userRepository.List().FirstOrDefault(user => user.Login == login) is { })
                {
                    //throw new UnprocessableEntityApplicationException(_logger,
                    //    $"Пользователь с логином={login} уже существует",
                    //    "Измените логин");
                }
        }

        public void UpdatePassword(User user, string password)
        {
            user.UpdatePassword(password);

            _userRepository.Update(user);
        }

    }
}
