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
    public class ListItemService:IListItemService
    {
        private readonly IListItemRepository _listItemRepository;
        private readonly IMapper _mapper;
        public ListItemService(IListItemRepository listItemRepository, IMapper mapper)
        {
            _listItemRepository = listItemRepository;
            _mapper = mapper;
        }
        public int Add(ListItem_Dto_Cu dto)
        {
            return _listItemRepository.Add(_mapper.Map<ListItem>(dto));
        }

        public bool Delete(int id)
        {
            return _listItemRepository.Delete(id);
        }

        public List<ListItem_Dto_R> Get()
        {
            return _mapper.Map<List<ListItem_Dto_R>>(_listItemRepository.Get());
        }

        public ListItem_Dto_R Get(int id)
        {
            return _mapper.Map<ListItem_Dto_R>(_listItemRepository.Get(id));
        }

        public bool Update(int id, ListItem_Dto_Cu dto)
        {
            return _listItemRepository.Update(id, _mapper.Map<ListItem>(dto));
        }
    }
}
