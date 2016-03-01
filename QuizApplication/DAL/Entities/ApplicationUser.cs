using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public DateTime AddedDate { get; set; }
        //public DateTime LastVisitDate { get; set; }
        public string AvatarPath { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }



        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TestPass> TestPasses { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
