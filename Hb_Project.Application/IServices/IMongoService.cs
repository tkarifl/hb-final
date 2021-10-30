using Hb_Project.Application.Dto.Read;
using System;
using System.Collections.Generic;
using Hb_Project.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.IServices
{
    public interface IMongoService
    {
        public List<Report_Dto> GetGeneralFavouriteItems();
        public List<Report_Dto> GetUserFavouriteItems(int id);

    }
}
