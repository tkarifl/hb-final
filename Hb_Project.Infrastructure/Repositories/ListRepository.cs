using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Repositories
{
    public class ListRepository : BaseRepository<List>, IListRepository
    {
        private readonly hb_ecommerceContext _context;

        public ListRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public override bool Update(int id, List newEntity)
        {
            var oldEntity = _context.Lists.AsNoTracking().FirstOrDefault(x => id == x.Id);
            if (oldEntity != null && oldEntity.UserId == newEntity.UserId)
            {
                return base.Update(id, newEntity);
            }
            return false;
        }
    }
}
