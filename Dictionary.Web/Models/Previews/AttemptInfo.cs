namespace Dictionary.Web.Models.Previews
{
    public class AttemptInfo
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
        ///     Отметка о том, что попытка была успешной.
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
