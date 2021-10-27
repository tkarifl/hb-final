using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hb_Project.Domain.Entities
{
    public partial class ListItem: IBaseEntity
    {
        public int? Id { get; set; }
        public int ListId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual List List { get; set; }
    }
}
