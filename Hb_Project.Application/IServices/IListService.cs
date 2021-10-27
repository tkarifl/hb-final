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
    public interface IListService
    {
        List<List_Dto_R> Get();
        List_Dto_R? Get(int id);
        bool Update(int id, List_Dto_Cu dto);
        bool Add(List_Dto_Cu dto);
        bool Delete(int id);
    }
}
