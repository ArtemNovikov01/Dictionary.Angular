using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Dictionary.Domain.Exception
{
    public class UnprocessableEntityApplicationException : ApplicationException
    {
        public UnprocessableEntityApplicationException(ILogger logger, string message, string additionalInfo = null) 
            : base(message)
        {
            logger.Error($"Пользовательское сообщение: {message}; дополнительная информация: {additionalInfo}.");
        }

        public UnprocessableEntityApplicationException(string message)
            : base(message)
        { }
    }
}
