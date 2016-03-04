using System.Collections;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<UserDto> GetUsers();
    }
}
