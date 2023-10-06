using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Models;

namespace Dictionary.Domain.Services.Contracts
{
    public interface IWordService
    {
        IEnumerable<Word> Get();
        Word Get(int id);
        void Add(int id, AddWordModel model);
        void Update(int id, UpdateWordModel model);
        void Delete(int id);
        void Delete(IEnumerable<int> ids);
    }
}
