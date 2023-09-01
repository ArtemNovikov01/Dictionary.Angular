using Dictionary.Domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Repositoreis.Base
{
    public abstract class RepositoriesBase<TEntity> : RepositoriesReadBase<TEntity>, IRepositoriesBase<TEntity>, IRepositoriesReadBase<TEntity> where TEntity : class
    {
        public RepositoriesBase(DbContext context)
            :base(context) 
        {  
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
