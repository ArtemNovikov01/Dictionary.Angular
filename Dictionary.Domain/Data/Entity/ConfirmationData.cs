using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Entity
{
    /// <summary>
    ///     Сущность данных подтверждения почты.
    /// </summary>
    public class ConfirmationData
    {
        private ConfirmationData() { }

        public ConfirmationData(string email, string code)
        {
            Email = email;
            Code = code;
        }

        public int Id { get; set; }

        /// <summary>
        ///     Адрес электронной почты.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        ///     Код подтверждения.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        ///     Количество попыток ввода кода подтверждения.
        /// </summary>
        public int AttemptsNumber { get; private set; }

        /// <summary>
        ///     Получает отметку о том, что достигнуто максимальное количество допустимых попыток.
        /// </summary>
        public bool IsAttemptsMaxNumber { get => AttemptsNumber >= 3; }

        /// <summary>
        ///     Дата создания записи.
        /// </summary>
        public DateTime CreationDate { get; private set; } = DateTime.Now.ToUniversalTime();

        public void AddAttempt() => AttemptsNumber++;
    }
}
