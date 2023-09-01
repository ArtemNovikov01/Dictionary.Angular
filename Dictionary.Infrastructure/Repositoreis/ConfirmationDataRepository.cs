using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Infrastructure.Data;
using Dictionary.Infrastructure.Repositoreis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class ConfirmationDataRepository : RepositoriesBase<ConfirmationData>, IConfirmationDataRepository
    {
        public ConfirmationDataRepository(DictionaryContext context) : base(context)
        { }
    }
}
