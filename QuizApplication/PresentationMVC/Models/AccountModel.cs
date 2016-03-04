using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationMVC.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

        public string AvatarPath { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
//
//    public class RegisterModel
//    {
//        [Required]
//        [Display(Name = "Логин")]
//        public string Login { get; set; }
//
//        [Required]
//        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Пароль")]
//        public string Password { get; set; }
//
//        [DataType(DataType.Password)]
//        [Display(Name = "Подтверждение пароля")]
//        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
//        public string ConfirmPassword { get; set; }
//
//        [Required(ErrorMessage = "Введите адрес электронной почты")]
//        [RegularExpression(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Введите кoрректный email")]
//        public string Email { get; set; }
//
//        [Required]
//        [Display(Name = "Имя")]
//        [RegularExpression(@"^[А-Я]+[а-я]{2,20}$", ErrorMessage = "Введите корректное имя")]
//        public string FirstName { get; set; }
//
//        [Required]
//        [Display(Name = "Фамилия")]
//        [RegularExpression(@"^[А-Я]+[а-я]{2,30}$", ErrorMessage = "Введите корректную фамилию")]
//        public string LastName { get; set; }
//
//        public string Passport { get; set; }
//
//        [Display(Name = "Номер телефона")]
//        [RegularExpression(@"\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Введите правильный номер телефона (ххх) ххх-хх-хх")]
//        public string Phone { get; set; }
//    }
//
//    public class ChangePasswordModel
//    {
//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Теущий пароль")]
//        public string OldPassword { get; set; }
//
//        [Required]
//        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Новый пароль")]
//        public string Password { get; set; }
//
//        [DataType(DataType.Password)]
//        [Display(Name = "Подтверждение пароля")]
//        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
//        public string ConfirmPassword { get; set; }
//    }
}