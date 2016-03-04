using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{

    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        

        public AccountService(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            _mapper = config.CreateMapper();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _mapper.Map<IEnumerable<User>,
            List<UserDto>>(_database.Users.GetAll());
        }
    }
}
