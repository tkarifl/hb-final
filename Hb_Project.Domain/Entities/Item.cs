using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hb_Project.Domain.Entities
{
    public partial class Item: IBaseEntity
    {
        public Item()
        {
            ListItems = new HashSet<ListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}
