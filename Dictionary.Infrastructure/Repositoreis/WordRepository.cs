using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Infrastructure.Data;
using RepositoriesAndSpecification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class WordRepository : RepositoriesBase<Word>, IWordRepository
    {
        public readonly DictionaryContext _context;
        public WordRepository(DictionaryContext context) :base(context) 
        {
            _context = context;
        }
    }
}
