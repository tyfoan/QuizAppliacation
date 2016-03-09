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
        public int UserId { get; set; }
        public string Email { get; set; }

        public bool IsBlocked { get; set; }
        public string AvatarPath { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        //public List<Role> Roles { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
        public List<TestPassViewModel> TestPasses { get; set; }

    }
}
