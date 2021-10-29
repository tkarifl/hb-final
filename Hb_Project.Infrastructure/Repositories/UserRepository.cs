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
        private hb_ecommerceContext _dbContext;
        public UserRepository(hb_ecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override bool Delete(int id)
        {
            try
            {
                var userToDelete = _dbContext.Users.Include(s => s.Lists).ThenInclude(s => s.ListItems).FirstOrDefault(x => x.Id == id);
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
                                _dbContext.ListItems.Remove(userListItem);
                            }
                        }
                        _dbContext.Lists.Remove(userList);
                    }

                }
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChanges();
                //callMongoDelete;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
