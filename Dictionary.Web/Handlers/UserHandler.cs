using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Domain.Services.Contracts;
using Dictionary.Web.Handlers.Contracts;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Previews;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserMapper _userMapper;
        private readonly IUserService _userService;
        private readonly IAttemptInfoMapper _attemptInfoMapper;
        private readonly IConfirmationDataService _confirmationDataService;

        public UserHandler(
            IConfirmationDataService confirmationDataService,
            IAttemptInfoMapper attemptInfoMapper,
            IUserService userService,
            IUserMapper userMapper
            )
        {
            _confirmationDataService = confirmationDataService;
            _attemptInfoMapper = attemptInfoMapper;
            _userService = userService;
            _userMapper = userMapper;
        }

        public void AddUser(AddUserRequest request)
        {
            _userService.AddUser(_userMapper.ToModel(request));
        }

        public async Task<bool> SendConfirmationCodeByEmailAsync(SendByEmailRequest request)
        {
            return await _confirmationDataService.SendConfirmationCodeByEmailAsync(request.Email.Trim());
        }

        public AttemptInfo MatchConfirmationCode(MatchConfirmationCodeRequest request)
        {
            var result = _confirmationDataService.MatchConfirmationCode(request.Email.Trim(), request.ConfirmationCode.Trim());

            return _attemptInfoMapper.ToAttemptInfo(result);
        }

        public AttemptInfo PasswordRecovery(PasswordRecoveryRequest request)
        {
            var result = _userService.PasswordRecovery(request.Email.Trim(), request.ConfirmationCode.Trim(), request.Password.Trim());

            return _attemptInfoMapper.ToAttemptInfo(result);
        }
    }
}
