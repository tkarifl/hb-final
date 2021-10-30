using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Repositories
{
    public class ListItemRepository : BaseRepository<ListItem>, IListItemRepository
    {
        private readonly hb_ecommerceContext _context;
        private readonly IMongoRepository _mongoRepository;
        public ListItemRepository(hb_ecommerceContext dbContext, IMongoRepository mongoRepository) : base(dbContext)
        {
            _context = dbContext;
            _mongoRepository = mongoRepository;
        }

        //prevent putting same item to same list
        public override int Add(ListItem entity)
        {
            if (!_context.ListItems.Any(listItem => entity.ListId == listItem.ListId && entity.ItemId == listItem.ItemId))
            {
                return base.Add(entity);
            }
            return 0;
        }

        //prevent putting same item to same list
        public override bool Update(int id,ListItem entity)
        {
            if (!_context.ListItems.Any(listItem => entity.ListId == listItem.ListId && entity.ItemId == listItem.ItemId))
            {
                return base.Update(id,entity);
            }
            return false;
        }

    }
}
