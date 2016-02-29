using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        //public DateTime AddedDate { get; set; }
        //public DateTime LastVisitDate { get; set; }
        public string AvatarPath { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }



        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TestPass> TestPasses { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
