using Dictionary.Domain.Exception;
using Dictionary.Web.Models.Request;
using Dictionary.Web.Validators.Authorization.Contracts;
using Dictionary.Web.Validators.Base;
using Dictionary.Web.Validators.Rules;

namespace Dictionary.Web.Validators.Authorization
{
    public class RegistrationValidator : ValidatorBase, IRegistrationValidator
    {
        private string _login;
        private string _password;
        private string _email;

        public RegistrationValidator(AddUserRequest addUserRequest) 
        {
            _login = CheckNull(addUserRequest.Login);
            _password = CheckNull(addUserRequest.Password);
            _email = CheckNull(addUserRequest.Email);
        }

        public void CheckValid()
        {
            var CheckPassword = new RulesRegist(_password);

            if (!CheckPassword.PasswordLength())
                throw new UnprocessableEntityApplicationException("Длина пароля должна быть не меньше 8 символов.");
            
            if(!CheckPassword.PasswordUpperCase())
                throw new UnprocessableEntityApplicationException("В пароле должно быть не меньше одного символа в верхнем регистре.");

            if (!CheckPassword.PasswordContente())
                throw new UnprocessableEntityApplicationException("В пароле должен содержаться хотя бы один из данных символов:{'!', '@', '#', '$', '%', '^', '&', '*'}");

            var CheckEmail = new RulesRegist(_email);

            if(!CheckEmail.EmailRegex())
                throw new UnprocessableEntityApplicationException("Неправильный формат эл.почты");
        }

       
    }
}
