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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public bool Add(Item_Dto_Cu dto)
        {
            return _itemRepository.Add(_mapper.Map<Item>(dto));
        }

        public bool Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public List<Item_Dto_R> Get()
        {
            return _mapper.Map<List<Item_Dto_R>>(_itemRepository.Get());
        }

        public Item_Dto_R Get(int id)
        {
            return _mapper.Map<Item_Dto_R>(_itemRepository.Get(id));
        }

        public bool Update(int id, Item_Dto_Cu dto)
        {
            return _itemRepository.Update(id, _mapper.Map<Item>(dto));
        }
    }
}
