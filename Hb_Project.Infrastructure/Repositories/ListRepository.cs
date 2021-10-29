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
        private hb_ecommerceContext _context;

        public ListRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        //delete list with related entities
        public override bool Delete(int id)
        {
            try
            {
                var listToDelete = _context.Lists.Include(s => s.ListItems).FirstOrDefault(x => x.Id == id);
                if (listToDelete == null)
                    return false;
                if (listToDelete.ListItems.Count > 0)
                {
                    foreach (ListItem listItem in listToDelete.ListItems)
                    {
                        _context.ListItems.Remove(listItem);
                    }
                }
                _context.Lists.Remove(listToDelete);
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
