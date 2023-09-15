using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Repositories.Contract
{
    public interface IUserRepository : IRepositoriesBase<User>
    {
        User GetWithRoleAndSession(string login, string password);
        User GetByIdWithRoleAndSession(int id);
        Task<User> GetByIdWithRoleAndSessionAsync(int id);
    }
}
