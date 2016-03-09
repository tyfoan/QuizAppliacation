using System;
using System.Collections;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetDto(int id);
        bool Edit(UserDto userDto);
        bool BlockingUser(int id);
        bool IsUserBlocked(string email);
    }
}
