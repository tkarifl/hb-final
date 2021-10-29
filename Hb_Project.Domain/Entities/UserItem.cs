using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Domain.Entities
{
    public class UserItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("listItemId")]
        public int ListItemId { get; set; }
        [BsonElement("userId")]
        public int UserId { get; set; }
        [BsonElement("listId")]
        public int ListId { get; set; }
        [BsonElement("itemId")]
        public int ItemId { get; set; }

    }
}
