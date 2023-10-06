using Dictionary.Domain.Data.Entity;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Handlers.Contracts
{
    public interface IWordHandler
    {
        IEnumerable<Word> Get();
        Word Get(int id);
        void Add(int id, AddWordRequest request);
        void Update(int id, UpdateWordRequest request);
        void Delete(int id);
        void Delete(IEnumerable<int> ids);

    }
}
