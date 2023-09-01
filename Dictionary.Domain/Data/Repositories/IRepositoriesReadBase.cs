using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Repositories
{
    public interface IRepositoriesReadBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        List<TEntity> List();
    }
}
