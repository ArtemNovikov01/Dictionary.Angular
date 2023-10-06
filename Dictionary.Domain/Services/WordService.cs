using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Domain.Exception;
using Dictionary.Domain.Services.Contracts;

namespace Dictionary.Domain.Services
{
    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;
        public WordService(IWordRepository wordRepository) 
        {
            _wordRepository = wordRepository;
        }

        public IEnumerable<Word> Get() => _wordRepository.List();

        public Word Get(int id) => _wordRepository.GetById(id);

        public void Add(int id, AddWordModel model) => _wordRepository.Add(new Word(model.EngWord, model.RusWord, model.Transcription, id));
        
        public void Update(int id, UpdateWordModel model)
        {
            var word = _wordRepository.List().FirstOrDefault(word=>word.Id == id)
                ?? throw new UnprocessableEntityApplicationException("Слова не существует.");

            word.Update(model);

            _wordRepository.Update(word);
        }

        public void Delete(int id) => _wordRepository.Delete(id);

        public void Delete(IEnumerable<int> ids)
        {
            foreach(var id in ids)
            {
                _wordRepository.Delete(id);
            }
        }
    }
}
