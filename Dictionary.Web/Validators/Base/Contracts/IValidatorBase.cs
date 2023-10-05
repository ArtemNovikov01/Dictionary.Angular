namespace Dictionary.Web.Validators.Base.Contracts
{
    public interface IValidatorBase
    {
        Type CheckNull<Type>(Type value);
    }
}
