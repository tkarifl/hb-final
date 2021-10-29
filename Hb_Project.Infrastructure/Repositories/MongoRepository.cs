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
        private readonly IMongoCollection<UserItem> _userItems;
        private hb_ecommerceContext _context;
        public MongoRepository(hb_ecommerceContext dbContext)
        {
            var client = new MongoClient(DbConnections.mongoConnection);
            var database = client.GetDatabase("hb_mongodb");
            _userItems = database.GetCollection<UserItem>("list_items");
            _context = dbContext;
        }

        //update mongo database from postresql
        //first, delete the items, which is not in postresql
        //secondly, add the postre items, which is not in mongo
        //thirdly, compare the remaining mongo items with postre items, if they do not match, replace mongo item with the new one
        public void UpdateMongo()
        {
            var newItems = _context.ListItems.ToList();
            var mongoItems = _userItems.Find(item => true).ToList();
            var itemsToDelete = mongoItems.Select(x => x.ListItemId).Except(newItems.Select(y => y.Id)).ToList();
            if (itemsToDelete.Count != 0)
            {
                foreach (int id in itemsToDelete)
                {
                    _userItems.DeleteOne(x => x.ListItemId == id);
                }
            }
            var itemsToAdd = newItems.Select(x => x.Id).Except(mongoItems.Select(y => y.ListItemId)).ToList();
            if (itemsToAdd.Count != 0)
            {
                foreach (int id in itemsToAdd)
                {
                    var newItem = newItems.Find(x => x.Id == id);
                    int userId = _context.Lists.First(x => x.Id == newItem.ListId).UserId;
                    _userItems.InsertOne(new UserItem { ItemId = newItem.ItemId, ListId = newItem.ListId, UserId = userId, ListItemId = id });
                }
            }
            mongoItems = _userItems.Find(item => true).ToList();
            foreach (UserItem item in mongoItems)
            {
                var newItem = newItems.Find(x => x.Id == item.ListItemId);
                int userId = _context.Lists.First(x => x.Id == newItem.ListId).UserId;
                if (item.ListId != newItem.ListId || item.ItemId != newItem.ItemId || item.UserId != userId)
                {
                    _userItems.DeleteOne(x => x.ListItemId == newItem.Id);
                    _userItems.InsertOne(new UserItem { ItemId = newItem.ItemId, ListId = newItem.ListId, UserId = userId, ListItemId = newItem.Id });
                }
            }
        }
        //public void AddItemLog(int itemId)
        //{
        //    var itemLog = _itemLogs.Find(log => log.ItemId == itemId).FirstOrDefault();
        //    if (itemLog == null)
        //    {
        //        _itemLogs.InsertOne(new ItemLog { ItemId = itemId, count = 1 });
        //    }
        //    else
        //    {
        //        itemLog.count += 1;
        //        _itemLogs.ReplaceOne(log => log.ItemId == itemId, itemLog);
        //    }
        //}

        //public void AddUserItemLog(int itemId, int userId, int listId)
        //{
        //    _userItemLogs.InsertOne(new UserItemLog { ItemId = itemId, UserId = userId, ListId = listId });
        //}

        //public void DeleteItemLog(int itemId)
        //{
        //    var itemLog = _itemLogs.Find(log => log.ItemId == itemId).FirstOrDefault();
        //    if (itemLog != null)
        //    {
        //        if (itemLog.count <= 1)
        //        {
        //            _itemLogs.DeleteOne(log => log.ItemId == itemId);
        //        }
        //        else
        //        {
        //            itemLog.count -= 1;
        //            _itemLogs.ReplaceOne(log => log.ItemId == itemId, itemLog);
        //        }
        //    }
        //}

        //public void DeleteUserItemLog(int itemId, int userId, int listId)
        //{
        //    var userItemLog = _userItemLogs.Find(log => log.ItemId == itemId && log.UserId == userId && log.ListId == listId).FirstOrDefault();
        //    if (userItemLog != null)
        //    {
        //        _userItemLogs.DeleteOne(log => log.Id == userItemLog.Id);
        //    }
        //}
    }
}
