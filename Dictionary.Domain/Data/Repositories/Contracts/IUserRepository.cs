using Dictionary.Domain.Data.Entity;
using Microsoft.EntityFrameworkCore;
using RepositoriesAndSpecification.Repositories.Contracts;

namespace Dictionary.Domain.Data.Repositories.Contract
{
    public interface IUserRepository : IRepositoriesBase<User>
    {
    }
}
