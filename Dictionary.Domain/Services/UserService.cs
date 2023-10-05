using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Domain.Exception;
using Dictionary.Domain.Services.Contracts;

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
            CheckLogin(model.Login, model.Email);
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

        private void CheckLogin(string login, string email)
        {
            var users = _userRepository.List();

            int countLogin = 0;
            int countEmail = 0;

            foreach (var user in users) 
            {
                if(user.Login == login) countLogin++;

                if(user.Email == email) countEmail++;
            }

            if (countLogin > 0)
                throw new UnprocessableEntityApplicationException($"Логин {login} занят другим пользователем.");

            if (countEmail > 0)
                throw new UnprocessableEntityApplicationException($"Аккаунт с эл.почтой {email} уже существует.");
        }

        public void UpdatePassword(User user, string password)
        {
            user.UpdatePassword(password);

            _userRepository.Update(user);
        }

    }
}
