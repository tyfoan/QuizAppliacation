using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = null)]
        public int UserId { get; set; }
        
        public string Email { get; set; }
        [Display(Name = "Блокировка")]
        public bool IsBlocked { get; set; }
        public string AvatarPath { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }


        //public List<Role> Roles { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
        public List<TestPassViewModel> TestPasses { get; set; }

    }
}
