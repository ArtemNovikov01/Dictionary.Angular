using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RepositoriesAndSpecification.Repositories;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class UserRepository : RepositoriesBase<User>, IUserRepository
    { 
        public readonly DictionaryContext _context;
        public UserRepository(DictionaryContext context) : base(context) 
        {
        _context = context;
    }
    }
}
