using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Hb_Project.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where
        T : class, IBaseEntity, new()
    {
        private readonly hb_ecommerceContext _context;
        DbSet<T> _dbSet;

        public BaseRepository(hb_ecommerceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual int Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            if (entity.Id != null)
            {
                return (int)entity.Id;
            }
            return 0;
        }

        public virtual bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public virtual List<T> Get()
        {
            return _dbSet.ToList();
        }

        public virtual T? Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Update(int id, T entity)
        {
            if (!_dbSet.Any(e => e.Id == id))
            {
                return false;
            }
            entity.Id = id;
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }
    }
}
