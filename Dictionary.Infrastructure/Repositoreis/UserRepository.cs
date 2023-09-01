using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Infrastructure.Data;
using Dictionary.Infrastructure.Repositoreis.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class UserRepository : RepositoriesBase<User>, IUserRepository
    {
        private readonly DictionaryContext _context;

        public UserRepository(DictionaryContext context) :base(context) 
        { 
            _context = context;
        }
    }
}
