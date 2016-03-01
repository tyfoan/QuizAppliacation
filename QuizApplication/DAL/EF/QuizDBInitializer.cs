using DAL.Entities;
using Enums;
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
            List<Subject> subjects = new List<Subject>()
            {
                new Subject() { SubjectId = Guid.NewGuid(), Complexity = Complexity.Starter, Name = "Вокруг света", Rate = null, TestAmount = 1 },
                new Subject() { SubjectId = Guid.NewGuid(), Complexity = Complexity.Starter, Name = "Back end", Rate = null, TestAmount = 3 }
            };
            subjects.ForEach(s => context.Subjects.Add(s));


            
            List<Test> tests = new List<Test>() 
            {
                new Test() { TestId = Guid.NewGuid(), Name = "Общеобразовательный тест", Complexity = Complexity.Starter, Rate = null, Duration = 60*30, Subject = subjects[0]},
                new Test() { TestId = Guid.NewGuid(), Name = "Тест по специальности .net", Complexity = Complexity.Starter, Rate = null, Duration = 60*36 , Subject = subjects[1]},
                new Test() { TestId = Guid.NewGuid(), Name = "Тест на беременность", Complexity = Complexity.Starter, Rate = null, Duration = 60*36, Subject = subjects[1] },
                new Test() { TestId = Guid.NewGuid(), Name = "Тост за дружбу", Complexity = Complexity.Starter, Rate = null, Duration = 60*36 , Subject = subjects[1] }
            };

            tests.ForEach(s => context.Tests.Add(s));


            List<Theme> themes = new List<Theme>()
            {
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Массивы", Test = tests[0] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Переменные", Test = tests[0] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Типы данных", Test = tests[0] },

                new Theme() { ThemeId = Guid.NewGuid(), Name = "Условные конструкции", Test = tests[1] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Методы", Test = tests[1] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Виды методов", Test = tests[1] },

                new Theme() { ThemeId = Guid.NewGuid(), Name = "Логические операции", Test = tests[2] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Побитовые операции", Test = tests[2] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Циклические конструкции", Test = tests[2] },

                new Theme() { ThemeId = Guid.NewGuid(), Name = "Знакомство с языком C#", Test = tests[3] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Машинная математика", Test = tests[3] },
                new Theme() { ThemeId = Guid.NewGuid(), Name = "Системы исчисления", Test = tests[3] }

            };
            themes.ForEach(x => context.Themes.Add(x));

            List<Question> questions = new List<Question>()
            {
                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "Какое имя отца А. С. Пушкина?", Test = tests[0] },
                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "О чем книга Тихий Дон?", Test = tests[0] },
                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "По чем сиги?", Test = tests[1] },

                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "Какое имя отца А. С. Пушкина?", Test = tests[1] },
                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "О чем книга Тихий Дон?", Test = tests[2] },
                new Question() { QuestionId = Guid.NewGuid(), QuestionContent = "По чем сиги?", Test = tests[3] }
            };
            questions.ForEach(s => context.Questions.Add(s));


            List<Answer> answers_q1 = new List<Answer>() 
            {
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Сергей", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[0]},
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Константин", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[0] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Александр", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[0] },

                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О реке", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[1] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О малчаливых испанцах", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[1] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О гражданской войне в России", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[1] },

                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "За два забирай", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[2] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "По фиг", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[2] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Все по 3", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[2] },


                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Сергей", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[3]},
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Константин", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[3] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Александр", StudentsAnswer = "", TrueAnswer = "Сергей", Question = questions[3] },

                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О реке", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[4] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О малчаливых испанцах", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[4] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "О гражданской войне в России", StudentsAnswer = "", TrueAnswer = "О малчаливых испанцах", Question = questions[4] },

                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "За два забирай", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[5] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "По фиг", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[5] },
                new Answer() { AnswerId = Guid.NewGuid(), IsTrue = true, ContentAnswer= "Все по 3", StudentsAnswer = "", TrueAnswer = "За два забирай", Question = questions[5] }

            };
            answers_q1.ForEach(s => context.Answers.Add(s));










            //context.Subjects.Add(new Subject() { SubjectId = Guid.NewGuid(), Complexity = Complexity.Starter, Name = "Вокруг света", Rate = null, TestAmount = tests.Count, Tests = tests });

            //List<User> users = new List<User>()
            //{
            //    new User() { UserId = Guid.NewGuid(), AddedDate = new DateTime(1994,12,01), FirstName = "Alexander", LastName="Ogurtsov", MiddleName="Juriovich", AvatarPath="", Login = "tyfoan", Password = "12345" }
            //};
            //users.ForEach(s => context.Users.Add(s));

            //List<Role> roles = new List<Role>()
            //{
            //    new Role() { Name = "Student", RoleId = Guid.NewGuid(), Users = users },
            //    new Role() { Name = "Teacher", RoleId = Guid.NewGuid() },
            //    new Role() { Name = "Admin", RoleId = Guid.NewGuid() }
            //};
            //roles.ForEach(s => context.Roles.Add(s));

        }
    }
}
