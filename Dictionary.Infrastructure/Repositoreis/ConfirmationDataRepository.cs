using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Infrastructure.Data;
using RepositoriesAndSpecification.Repositories;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class ConfirmationDataRepository : RepositoriesBase<ConfirmationData>, IConfirmationDataRepository
    {
        public ConfirmationDataRepository(DictionaryContext context) : base(context)
        { }
    }
}
