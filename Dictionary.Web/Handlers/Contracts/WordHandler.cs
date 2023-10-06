using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Services.Contracts;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Handlers.Contracts
{
    public class WordHandler : IWordHandler
    {
        private IWordService _wordService;
        private IWordMapper _wordMapper;
        public WordHandler(IWordService wordService,
                           IWordMapper wordMapper) 
        {
            _wordService = wordService;
            _wordMapper = wordMapper;
        }

        public IEnumerable<Word> Get() => _wordService.Get();
        public Word Get(int id) => _wordService.Get(id);
        public void Add(int id, AddWordRequest request)
        {
            _wordService.Add(id, _wordMapper.ToModel(request));
        }
        public void Update(int id, UpdateWordRequest request)
        {
            _wordService.Update(id, _wordMapper.ToModel(request));
        }
        public void Delete(int id)
        {
            _wordService.Delete(id);
        }
        public void Delete(IEnumerable<int> ids)
        {
            _wordService.Delete(ids);
        }
    }
}
