﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Domain.Entities
{
    public interface IBaseEntity
    {
        public int? Id { get; set; }
    }
}
