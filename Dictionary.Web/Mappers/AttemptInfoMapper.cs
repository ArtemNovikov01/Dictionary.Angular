using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Previews;

namespace Dictionary.Web.Mappers
{
    public class AttemptInfoMapper : IAttemptInfoMapper
    {
        public AttemptInfo ToAttemptInfo(MatchConfirmationCodeInfo matchConfirmationCodeInfo) =>
            new()
            {
                LeftAttemptsNumber = matchConfirmationCodeInfo.LeftAttemptsNumber,
                IsAttemptsMaxNumber = matchConfirmationCodeInfo.IsAttemptsMaxNumber,
                IsSuccess = matchConfirmationCodeInfo.IsMatch
            };

        public AttemptInfo ToAttemptInfo(PasswordRecoveryInfo passwordRecoveryInfo) =>
            new()
            {
                LeftAttemptsNumber = passwordRecoveryInfo.MatchConfirmationCodeInfo.LeftAttemptsNumber,
                IsAttemptsMaxNumber = passwordRecoveryInfo.MatchConfirmationCodeInfo.IsAttemptsMaxNumber,
                IsSuccess = passwordRecoveryInfo.IsPasswordChangeSuccess
            };
    }
}
