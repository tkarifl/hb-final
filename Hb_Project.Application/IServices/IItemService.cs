using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace Hb_Project.Application.IServices
{
    public interface IItemService
    {
        List<Item_Dto_R> Get();
        Item_Dto_R? Get(int id);
        bool Update(int id, Item_Dto_Cu dto);
        bool Add(Item_Dto_Cu dto);
        bool Delete(int id);
    }
}
