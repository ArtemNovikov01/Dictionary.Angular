using Dictionary.Domain.Data.Models;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Mappers
{
    public class WordMapper : IWordMapper
    {
        public AddWordModel ToModel(AddWordRequest request)
            =>
            new()
            {
                EngWord = request.EngWord,
                RusWord = request.RusWord,
                Transcription = request.Transcription
            };

        public UpdateWordModel ToModel(UpdateWordRequest request)
            =>
            new()
            {
                EngWord = request.EngWord,
                RusWord = request.RusWord,
                Transcription = request.Transcription
            };
    }
}
