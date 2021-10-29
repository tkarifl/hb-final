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
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private hb_ecommerceContext _context;
        public ItemRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        //delete item and related entities
        public override bool Delete(int id)
        {
            try
            {
                var itemToDelete = _context.Items.Include(s => s.ListItems).FirstOrDefault(x => x.Id == id);
                if (itemToDelete == null)
                    return false;
                if (itemToDelete.ListItems.Count > 0)
                {
                    foreach (ListItem listItem in itemToDelete.ListItems)
                    {
                        _context.ListItems.Remove(listItem);
                    }
                }
                _context.Items.Remove(itemToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
