using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Web.Models.Previews;

namespace Dictionary.Web.Mappers.Contracts
{
    public interface IAttemptInfoMapper
    {
        AttemptInfo ToAttemptInfo(MatchConfirmationCodeInfo matchConfirmationCodeInfo);
        AttemptInfo ToAttemptInfo(PasswordRecoveryInfo matchConfirmationCodeInfo);

    }
}
