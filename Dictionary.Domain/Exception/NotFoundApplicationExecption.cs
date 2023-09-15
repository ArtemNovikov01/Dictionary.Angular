using Serilog;

namespace Dictionary.Domain.Exception
{
    public class NotFoundApplicationExecption : ApplicationException
    {
        NotFoundApplicationExecption(ILogger logger, string message, string additionalInfo = null)
        : base(message) 
        {
            logger.Error($"Пользовательское сообщение: {message}; дополнительная информация: {additionalInfo}.");
        }

        public NotFoundApplicationExecption(ILogger logger, string message, string entityName, string entityId) 
            :base(message) 
        {
            logger.Error($"Пользовательское сообщение: {message};" +
               $" дополнительная информация: запрашиваемая(ые) сущность(и) типа {entityName} не найдена(ы) по идентификатору(ам): {entityId}.");
        }

        public NotFoundApplicationExecption(ILogger logger, string message, string entityName, string entityId, string requesterId)
            : base(message)
        {
            logger.Error($"Пользовательское сообщение: {message};" +
                $" дополнительная информация: запрашиваемая сущность типа {entityName} не найдена" +
                $" или недоступна по идентификатору: {entityId} для пользователя с идентификатором: {requesterId}.");
        }
    }
}
