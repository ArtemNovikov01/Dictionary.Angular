using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Models.Configuration
{
    /// <summary>
    ///     Информация о попытке восстановления пароля.
    /// </summary>
    public class PasswordRecoveryInfo
    {
        public MatchConfirmationCodeInfo MatchConfirmationCodeInfo { get; set; }

        /// <summary>
        ///     Отметка о том, что попытка восстановления пароля была успешной.
        /// </summary>
        public bool IsPasswordChangeSuccess { get; set; }
    }
}
