using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Hb_Project.Application.Dto.Create_Update
{
    public class User_Dto_Cu
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Gsm { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
