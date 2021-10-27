using AutoMapper;
using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.Dto.Read;
using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, User_Dto_Cu>().ReverseMap();
            CreateMap<User, User_Dto_R>().ReverseMap();
            CreateMap<Item, Item_Dto_Cu>().ReverseMap();
            CreateMap<Item, Item_Dto_R>().ReverseMap();
            CreateMap<ListItem, ListItem_Dto_Cu>().ReverseMap();
            CreateMap<ListItem, ListItem_Dto_R>().ReverseMap();
            CreateMap<List, List_Dto_Cu>().ReverseMap();
            CreateMap<List, List_Dto_R>().ReverseMap();
        }
    }
}
