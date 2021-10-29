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
        public ListItemRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
        }
    }
}
