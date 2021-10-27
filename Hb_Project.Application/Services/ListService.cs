using AutoMapper;
using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.Dto.Read;
using Hb_Project.Application.IServices;
using Hb_Project.Domain.Entities;
using Hb_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb_Project.Application.Services
{
    public class ListService:IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;
        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }
        public int Add(List_Dto_Cu dto)
        {
            return _listRepository.Add(_mapper.Map<List>(dto));
        }

        public bool Delete(int id)
        {
            return _listRepository.Delete(id);
        }

        public List<List_Dto_R> Get()
        {
            return _mapper.Map<List<List_Dto_R>>(_listRepository.Get());
        }

        public List_Dto_R Get(int id)
        {
            return _mapper.Map<List_Dto_R>(_listRepository.Get(id));
        }

        public bool Update(int id, List_Dto_Cu dto)
        {
            return _listRepository.Update(id, _mapper.Map<List>(dto));
        }
    }
}
