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
    public class ListItemService : IListItemService
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
        public string BulkAdd(List<ListItem_Dto_Cu> dtoList)
        {
            int totalDtos = dtoList.Count;
            int addedDtos = 0;
            foreach (ListItem_Dto_Cu dto in dtoList)
            {
                if (_listItemRepository.Add(_mapper.Map<ListItem>(dto)) != 0)
                {
                    addedDtos += 1;
                }
            }
            if (totalDtos == addedDtos)
            {
                return $"{totalDtos} Items are added";
            }
            return $"{totalDtos} Out of {addedDtos} items are added.\n Same items in same list are not allowed.\n " +
                "If this is not the case, make sure listid and itemid pointing real entities";
        }

        public string BulkDelete(List<int> dtoList)
        {
            int totalDtos = dtoList.Count;
            int deletedDtos = 0;
            foreach (int id in dtoList)
            {
                if (_listItemRepository.Delete(id))
                {
                    deletedDtos += 1;
                }
            }
            if (totalDtos == deletedDtos)
            {
                return $"{totalDtos} Items are deleted";
            }
            return $"{totalDtos} Out of {deletedDtos} items are deleted.\n Make sure id's pointing real entities";
        }
    }
}
