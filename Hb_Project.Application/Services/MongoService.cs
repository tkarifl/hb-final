using AutoMapper;
using Hb_Project.Application.Dto.Read;
using Hb_Project.Application.IServices;
using Hb_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.Services
{
    public class MongoService: IMongoService
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IMapper _mapper;

        public MongoService(IMongoRepository mongoRepository, IMapper mapper)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }

        public List<Report_Dto> GetGeneralFavouriteItems()
        {
            return _mapper.Map<List<Report_Dto>>(_mongoRepository.GetGeneralFavouriteItems());
        }

        public List<Report_Dto> GetUserFavouriteItems(int id)
        {
            return _mapper.Map<List<Report_Dto>>(_mongoRepository.GetUserFavouriteItems(id));
        }

        public void UpdateMongo()
        {
            _mongoRepository.UpdateMongo();
        }
    }
}
