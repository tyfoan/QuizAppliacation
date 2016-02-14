using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.EF
{
    class QuizDBInitializer : DropCreateDatabaseIfModelChanges<QuizContext>
    {
        protected override void Seed(QuizContext context)
        {
            List<Answer> answers_q1 = new List<Answer>() 
            {
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Сергей", StudentsAnswer = "", TrueAnswer = "Сергей" },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = false, ContentAnswer= "Константин", StudentsAnswer = "", TrueAnswer = "Сергей" },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = false, ContentAnswer= "Александр", StudentsAnswer = "", TrueAnswer = "Сергей" },

            };
            List<Answer> answers_q2 = new List<Answer>() 
            {
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = false, ContentAnswer= "О реке", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах" },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = false, ContentAnswer= "О малчаливых испанцах", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах" },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О гражданской войне в России", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах" }
            };
            answers_q1.ForEach(s => context.Answers.Add(s));
            answers_q2.ForEach(s => context.Answers.Add(s));


            List<Question> questions = new List<Question>()
            {
                new Question() { Answers = answers_q1, GuestionId = Guid.NewGuid(), QuestionContent = "Какое имя отца А. С. Пушкина?" },
                new Question() { Answers = answers_q2, GuestionId = Guid.NewGuid(), QuestionContent = "О чем книга Тихий Дон?" }
            };
            questions.ForEach(s => context.Questions.Add(s));


            List<Test> tests = new List<Test>() 
            {
                new Test() { TestId = Guid.NewGuid(), Name = "Общеобразовательный тест", Complexity = Complexity.Starter, Rate = null, QuestionAmount = questions.Count, Duration = 60*60*36, Questions = questions  }
            };
            tests.ForEach(s => context.Tests.Add(s));



            List<Subject> subjects = new List<Subject>()
            {
                new Subject() { SubjectId = Guid.NewGuid(), Complexity = Complexity.Starter, Name = "Вокруг света", Rate = null, TestAmount = tests.Count, Tests = tests }
            };
            subjects.ForEach(s => context.Subjects.Add(s));



            List<User> users = new List<User>()
            {
                new User() { UserId = Guid.NewGuid(), AddedDate = new DateTime(1994,12,01), FirstName = "Alexander", LastName="Ogurtsov", MiddleName="Juriovich", AvatarPath="", Login = "tyfoan", Password = "12345" }
            };
            users.ForEach(s => context.Users.Add(s));

            List<Role> roles = new List<Role>()
            {
                new Role() { Name = "Student", RoleId = Guid.NewGuid(), Users = users },
                new Role() { Name = "Teacher", RoleId = Guid.NewGuid() },
                new Role() { Name = "Admin", RoleId = Guid.NewGuid() }
            };
            roles.ForEach(s => context.Roles.Add(s));

        }
    }
}
