using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using PresentationMVC.Models.ViewModels;

namespace PresentationMVC.Models
{
#region 
    //    [Table("Users")]
    //    public class User
    //    {
    //        [Key]
    //        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //        public int UserId { get; set; }
    //        public string Email { get; set; }
    //        public string Login { get; set; }
    //        public string Password { get; set; }
    //        public string UserName { get; set; }
    //        public string FirstName { get; set; }
    //        public string Address { get; set; }
    //        public string Role { get; set; }

    //        public string AvatarPath { get; set; }
    //        public string MiddleName { get; set; }
    //        public string LastName { get; set; }
    //    }

    //    public class LoginModel
    //    {
    //        [Required]
    //        [Display(Name = "Логин")]
    //        public string Login { get; set; }


    //        //[Required(ErrorMessage = "Введите адрес электронной почты")]
    //        //[RegularExpression(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
    //        //public string Email { get; set; }


    //        [Required]
    //        [DataType(DataType.Password)]
    //        [Display(Name = "Пароль")]
    //        public string Password { get; set; }


    //        [Display(Name = "Запомнить меня?")]
    //        public bool RememberMe { get; set; }
    //    }

    //    public class RegisterModel
    //    {

    //        [Required]
    //        [Display(Name = "Логин")]
    //        public string Login { get; set; }

    //        [Required(ErrorMessage = "Введите адрес электронной почты")]
    //        [RegularExpression(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
    //        public string Email { get; set; }
    //        [Required]
    //        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов", MinimumLength = 6)]
    //        [DataType(DataType.Password)]
    //        [Display(Name = "Пароль")]
    //        public string Password { get; set; }

    //        [DataType(DataType.Password)]
    //        [Display(Name = "Подтверждение пароля")]
    //        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    //        public string ConfirmPassword { get; set; }



    //        [Required]
    //        [Display(Name = "Имя")]
    //        [RegularExpression(@"^[А-Я]+[а-я]{2,30}$", ErrorMessage = "Введите корректное имя.")]
    //        public string FirstName { get; set; }

    //        [Required]
    //        [Display(Name = "Фамилия")]
    //        [RegularExpression(@"^[А-Я]+[а-я]{2,30}$", ErrorMessage = "Введите корректную фамилию.")]
    //        public string LastName { get; set; }

    //        [Display(Name = "Адрес")]
    //        public string Address { get; set; }
    //    }
    ////
    ////    public class ChangePasswordModel
    ////    {
    ////        [Required]
    ////        [DataType(DataType.Password)]
    ////        [Display(Name = "Теущий пароль")]
    ////        public string OldPassword { get; set; }
    ////
    ////        [Required]
    ////        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов", MinimumLength = 6)]
    ////        [DataType(DataType.Password)]
    ////        [Display(Name = "Новый пароль")]
    ////        public string Password { get; set; }
    ////
    ////        [DataType(DataType.Password)]
    ////        [Display(Name = "Подтверждение пароля")]
    ////        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    ////        public string ConfirmPassword { get; set; }
    ////    }
#endregion
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

     [Table("Users")]

    public class UserProfile
    {
         [Key]
         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Email { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
