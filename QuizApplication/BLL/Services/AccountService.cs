using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{

    public class AccountService : IAccountService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;


        public AccountService(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _mapper.Map<IEnumerable<User>,
            List<UserDto>>(_database.Users.GetAll());
        }


        public UserDto GetDto(int id)
        {
            return _mapper.Map<User, UserDto>(_database.Users.Get(id));
        }


        public bool Edit(UserDto userDto)
        {
            var user = _database.Users.First(x => x.Email == userDto.Email);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.MiddleName = userDto.MiddleName;
            user.Address = userDto.Address;
            _database.Save();
            return true;
        }

        public bool BlockingUser(int id)
        {
            User account = _database.Users.First(x => x.UserId == id);
            account.IsBlocked = !account.IsBlocked;
            _database.Users.Update(account);
            _database.Save();
            return account.IsBlocked;
        }
    }
}
