using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Domain.Data.Repositories
{
    public interface IRepositoriesBase<TEntity> : IRepositoriesReadBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
