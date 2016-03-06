using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        //public DateTime AddedDate { get; set; }
        //public DateTime LastVisitDate { get; set; }
        public string AvatarPath { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        


        public List<SubjectDto> Subjects { get; set; }
        public List<TestPassDto> TestPasses { get; set; }
        public List<StudentAnswerDto> StudentAnswers { get; set; }

    }
}
