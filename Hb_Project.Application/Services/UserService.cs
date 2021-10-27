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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool Add(User_Dto_Cu dto)
        {
            return _userRepository.Add(_mapper.Map<User>(dto));
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public List<User_Dto_R> Get()
        {
            return _mapper.Map<List<User_Dto_R>>(_userRepository.Get());
        }

        public User_Dto_R Get(int id)
        {
            return _mapper.Map<User_Dto_R>(_userRepository.Get(id));
        }

        public bool Update(int id, User_Dto_Cu dto)
        {
            return _userRepository.Update(id, _mapper.Map<User>(dto));
        }
    }
}
