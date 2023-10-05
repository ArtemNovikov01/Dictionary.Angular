using Dictionary.Web.Validators.Base.Contracts;

namespace Dictionary.Web.Validators.Authorization.Contracts
{
    public interface IRegistrationValidator : IValidatorBase
    {
        void CheckValid();

    }
}
