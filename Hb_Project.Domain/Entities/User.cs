using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Hb_Project.Domain.Entities
{
    public partial class User: IBaseEntity
    {
        public User()
        {
            Lists = new HashSet<List>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }

        public virtual ICollection<List> Lists { get; set; }
    }
}
