using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Hb_Project.Application.Dto.Create_Update
{
    public class Item_Dto_Cu
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int DiscountedPrice { get; set; }

    }
}
