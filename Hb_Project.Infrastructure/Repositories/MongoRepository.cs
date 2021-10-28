using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using Hb_Project.Infrastructure.Extensions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Infrastructure.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoCollection<ItemLog> _itemLogs;
        private readonly IMongoCollection<UserItemLog> _userItemLogs;
        public MongoRepository()
        {
            var client = new MongoClient(DbConnections.mongoConnection);
            var database = client.GetDatabase("hb_mongodb");
            _itemLogs = database.GetCollection<ItemLog>("item_log");
            _userItemLogs = database.GetCollection<UserItemLog>("user_list_item_log");
        }
        public void AddItemLog(int itemId)
        {
            var itemLog = _itemLogs.Find(log => log.ItemId == itemId).FirstOrDefault();
            if (itemLog == null)
            {
                _itemLogs.InsertOne(new ItemLog { ItemId = itemId, count = 1 });
            }
            else
            {
                itemLog.count += 1;
                _itemLogs.ReplaceOne(log => log.ItemId == itemId, itemLog);
            }
        }

        public void AddUserItemLog(int itemId, int userId, int listId)
        {
            _userItemLogs.InsertOne(new UserItemLog { ItemId = itemId, UserId = userId, ListId = listId });
        }

        public void DeleteItemLog(int itemId)
        {
            var itemLog = _itemLogs.Find(log => log.ItemId == itemId).FirstOrDefault();
            if (itemLog != null)
            {
                if (itemLog.count <= 1)
                {
                    _itemLogs.DeleteOne(log => log.ItemId == itemId);
                }
                else
                {
                    itemLog.count -= 1;
                    _itemLogs.ReplaceOne(log => log.ItemId == itemId, itemLog);
                }
            }
        }

        public void DeleteUserItemLog(int itemId, int userId, int listId)
        {
            var userItemLog = _userItemLogs.Find(log => log.ItemId == itemId && log.UserId == userId && log.ListId == listId).FirstOrDefault();
            if (userItemLog != null)
            {
                _userItemLogs.DeleteOne(log => log.Id == userItemLog.Id);
            }
        }
    }
}
