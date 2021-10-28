using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Domain.Repositories
{
    public interface IMongoRepository
    {
        public void AddItemLog(int itemId);
        public void AddUserItemLog(int itemId, int userId, int listId);
        public void DeleteItemLog(int itemId);
        public void DeleteUserItemLog(int itemId, int userId, int listId);
    }
}
