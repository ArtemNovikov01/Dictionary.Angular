using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Models.Configuration;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Domain.Exception;
using Dictionary.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Services
{
    public class ConfirmationDataService : IConfirmationDataService
    {
        private readonly IConfirmationDataRepository _confirmationDataRepository;
        private readonly IMailManager _mailManager;

        public ConfirmationDataService(
            IConfirmationDataRepository confirmationDataRepository,
            IMailManager mailManager)
        {
            _confirmationDataRepository = confirmationDataRepository;
            _mailManager = mailManager;
        }
        public async Task<bool> SendConfirmationCodeByEmailAsync(string email)
        {
            var code = 123;

            var isSuccess = await _mailManager.SendAsync(email, "Подтверждение почты", $"Ваш код подтверждения: {code}");
            _confirmationDataRepository.Add(new ConfirmationData(email, code.ToString()));

            return isSuccess;
        }

        public MatchConfirmationCodeInfo MatchConfirmationCode(string email, string confirmationCode)
        {
            var confirmationData = _confirmationDataRepository.List().FirstOrDefault(confirmationData => confirmationData.Email == email)
                ?? throw new UnprocessableEntityApplicationException("Код недействителен, попробуйте получить его снова.");

            confirmationData.AddAttempt();

            var result = new MatchConfirmationCodeInfo()
            {
                IsAttemptsMaxNumber = confirmationData.IsAttemptsMaxNumber,
                LeftAttemptsNumber = 3 - confirmationData.AttemptsNumber

            };

            var isMatch = confirmationData.Code == confirmationCode;

            if (isMatch || confirmationData.IsAttemptsMaxNumber)
            {
                result.IsMatch = isMatch;
                _confirmationDataRepository.Delete(confirmationData);
            }
            else
            {
                _confirmationDataRepository.Update(confirmationData);
            }

            return result;
        }
    }
}
