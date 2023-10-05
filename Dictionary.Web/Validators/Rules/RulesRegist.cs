using System.Text.RegularExpressions;

namespace Dictionary.Web.Validators.Rules
{
    public class RulesRegist
    {
        private string _value;

        private char[] charList = { '!', '@', '#', '$', '%', '^', '&', '*' };

        public RulesRegist(string value)
        {
            _value = value;
        }

        /// <summary>
        ///     Пароль должен быть не меньше 8 символов.
        /// </summary>
        public bool PasswordLength() 
        {
            return (_value.Length - 7) > 0;
        } 

        /// <summary>
        ///     Пароль должен содержать хотябы один символ в верхнем регистре.
        /// </summary>
        public bool PasswordUpperCase()
        {
            return _value.Any(character => char.IsUpper(character));
        }

        /// <summary>
        ///     Пароль должен содержать хотя бы один из символов представленных в charList.
        /// </summary>
        public bool PasswordContente()
        {
            return _value.Any(c => charList.Contains(c));
        }

        public bool EmailRegex()
        {
            return Regex.IsMatch(_value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

    }
}
