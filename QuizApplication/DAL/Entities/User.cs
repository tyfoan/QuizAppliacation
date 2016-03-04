using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
        public virtual Role Role { get; set; }
    }
}
