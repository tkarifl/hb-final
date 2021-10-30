using Hb_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Domain.Repositories
{
    public interface IMongoRepository
    {
        public void UpdateMongo();
        public List<Report> GetGeneralFavouriteItems();
        public List<Report> GetUserFavouriteItems(int id);
    }
}
