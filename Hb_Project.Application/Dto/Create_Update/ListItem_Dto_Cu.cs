using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Hb_Project.Application.Dto.Create_Update
{
    public class ListItem_Dto_Cu
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        public int ItemId { get; set; }

    }
}
