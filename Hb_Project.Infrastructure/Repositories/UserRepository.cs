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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private hb_ecommerceContext _context;
        public UserRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        //delete user and related entities
        public override bool Delete(int id)
        {
            try
            {
                var userToDelete = _context.Users.Include(s => s.Lists).ThenInclude(s => s.ListItems).FirstOrDefault(x => x.Id == id);
                if (userToDelete == null)
                    return false;

                if (userToDelete.Lists.Count > 0)
                {
                    foreach (var userList in userToDelete.Lists)
                    {
                        if (userList.ListItems.Count > 0)
                        {
                            foreach (var userListItem in userList.ListItems)
                            {
                                _context.ListItems.Remove(userListItem);
                            }
                        }
                        _context.Lists.Remove(userList);
                    }

                }
                _context.Users.Remove(userToDelete);
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
