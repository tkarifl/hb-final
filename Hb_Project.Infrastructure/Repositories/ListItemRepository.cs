using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using Hb_Project.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Repositories
{
    public class ListItemRepository : BaseRepository<ListItem>, IListItemRepository
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly hb_ecommerceContext _context;
        DbSet<ListItem> _dbSet;

        public ListItemRepository(hb_ecommerceContext dbContext, IMongoRepository mongoRepository) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<ListItem>();
            _mongoRepository = mongoRepository;
        }
        public override int Add(ListItem entity)
        {
            if (!_dbSet.Any(listItem => entity.ListId == listItem.ItemId && entity.ItemId == listItem.ItemId))
            {
                int listItemId = base.Add(entity);
                if (listItemId != 0)
                {
                    _mongoRepository.AddItemLog(entity.ItemId);
                    var list = _context.Lists.First(x => entity.ListId == x.Id);
                    _mongoRepository.AddUserItemLog(entity.ItemId, list.UserId, entity.ListId);
                    return listItemId;
                }
            }
            return 0;
        }
        public override bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (base.Delete(id))
            {
                _mongoRepository.DeleteItemLog(entity.ItemId);
                var list = _context.Lists.First(x => entity.ListId == x.Id);
                _mongoRepository.DeleteUserItemLog(entity.ItemId, list.UserId, entity.ListId);
                return true;
            }
            return false;
        }
        public override bool Update(int id, ListItem newEntity)
        {
            var oldEntity = _dbSet.Find(id);
            if (base.Update(id, newEntity) && oldEntity != null)
            {
                _mongoRepository.DeleteItemLog(oldEntity.ItemId);
                _mongoRepository.AddItemLog(newEntity.ItemId);
                var oldEntityList = _context.Lists.First(x => oldEntity.ListId == x.Id);
                var newEntyityList = _context.Lists.First(x => newEntity.ListId == x.Id);
                _mongoRepository.DeleteUserItemLog(oldEntity.ItemId, oldEntityList.UserId, oldEntity.ListId);
                _mongoRepository.AddUserItemLog(newEntity.ItemId, newEntyityList.UserId, newEntity.ListId);
                return true;
            }
            return false;
        }
    }
}
