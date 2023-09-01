using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Models.Configuration
{
    /// <summary>
    ///     Информация о попытке подтверждения кода.
    /// </summary>
    public class MatchConfirmationCodeInfo
    {
        /// <summary>
        ///     Количество оставшихся попыток.
        /// </summary>
        public int LeftAttemptsNumber { get; set; }

        /// <summary>
        ///     Отметка о том, что достигнуто максимальное количество попыток.
        /// </summary>
        public bool IsAttemptsMaxNumber { get; set; }

        /// <summary>
        ///     Отметка о том, что попытка подтверждения кода была успешной.
        /// </summary>
        public bool IsMatch { get; set; }
    }
}
