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

        // add the parameter entity to db
        // if the foreign keys dont point to real entities, the db will throw exception
        // the foreign key exceptions are handled here, if they throw exception, it doesnt add any entity and the function simply returns 0;
        public virtual int Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _dbSet.Remove(entity);
                return 0;
            }
            return entity.Id;
        }

        // delete the parameter entity from db
        // the foreign keys point to real entities and if we try to delete the entity, the db will throw exception (because the other entities
        // still point to this entity)
        // the foreign key exceptions are handled here, if they throw exception, it doesnt delete any entity the function simply returns false;
        public virtual bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return false;
            }
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // get entities
        public virtual List<T> Get()
        {
            return _dbSet.ToList();
        }

        // get selected entity from id
        public virtual T? Get(int id)
        {
            return _dbSet.Find(id);
        }

        // update the parameter entity from db
        // exceptions are handled here, if the new entity's foreign keys dont point to real entity, this function will throw exception
        // if it throws exception, the function wont update the entity and returns false
        public virtual bool Update(int id, T entity)
        {
            if (!_dbSet.Any(e => e.Id == id))
            {
                return false;
            }
            entity.Id = id;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _context.Remove(entity);
                return false;
            }

            return true;
        }
    }
}
