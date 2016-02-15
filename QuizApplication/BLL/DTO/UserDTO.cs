using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
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


        public List<TestPassDTO> TestPasses { get; set; }
        public List<SubjectDTO> Subjects { get; set; }

    }
}
