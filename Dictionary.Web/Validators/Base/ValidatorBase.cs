using Dictionary.Web.Validators.Base.Contracts;

namespace Dictionary.Web.Validators.Base
{
    public class ValidatorBase : IValidatorBase
    {
        public Type CheckNull<Type>(Type value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Type));

            return value;
        }
    }
}
