using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Hb_Project.Domain.Entities
{
    public partial class List: IBaseEntity
    {
        public List()
        {
            ListItems = new HashSet<ListItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}
