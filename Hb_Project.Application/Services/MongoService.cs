using Hb_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.Services
{
    public class MongoService
    {
        private readonly IMongoRepository _mongoRepository;
        public MongoService(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public void UpdateMongo()
        {
            _mongoRepository.UpdateMongo();
        }
    }
}
