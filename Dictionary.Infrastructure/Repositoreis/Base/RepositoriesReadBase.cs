using Dictionary.Domain.Data.Repositories;
using Dictionary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Repositoreis.Base
{
    public class RepositoriesReadBase<TEntity> : IRepositoriesReadBase<TEntity> where TEntity : class
    {
        private protected readonly DbContext _context;
        public RepositoriesReadBase(DbContext context) 
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public List<TEntity> List()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
