using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Infrastructure.Data;
using Dictionary.Infrastructure.Repositoreis.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dictionary.Infrastructure.Repositoreis
{
    public class UserRepository : RepositoriesBase<User>, IUserRepository
    {
        public readonly DictionaryContext _context;

        public UserRepository(DictionaryContext context) :base(context) 
        { 
            _context = context;
        }

        public User GetWithRoleAndSession(string login, string password)
        {
            return _context.Users
                .Include(user => user.Role)
                .Include(user => user.Sessions)
                .FirstOrDefault(user => user.Login == login && user.Password == password);
        }

        public User GetByIdWithRoleAndSession(int id)
        {
            return _context.Users
                .Include(user => user.Role)
                .Include(user => user.Sessions)
                .FirstOrDefault(user => user.Id==id);
        }

        public async Task<User> GetByIdWithRoleAndSessionAsync(int id)
        {
            return await _context.Users
                .Include(user => user.Role)
                .Include(user => user.Sessions)
                .FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
