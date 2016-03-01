using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }



        public async Task<OperationDetails> Create(DTO.UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user ==null)
            {
                user = new ApplicationUser() {Email = userDto.Email, UserName = userDto.Email};
                await Database.UserManager.CreateAsync(user, userDto.Password);
                //добавить роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                //создать профиль клиента
                ClientProfile clientProfile = new ClientProfile()
                {
                    Id = user.Id,
                    Address = userDto.Address,
                    Name = userDto.FirstName
                };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");    
            }
        }

        public async Task<ClaimsIdentity> Authenticate(DTO.UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            //находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            //авторизируем его и возвращаем объект CLaimsIdentity
            if (user != null)
            {
                claim =
                    await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        //начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role ==null)
                {
                    role = new ApplicationRole() {Name = roleName};
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
           Database.Dispose();
        }
    }
}
