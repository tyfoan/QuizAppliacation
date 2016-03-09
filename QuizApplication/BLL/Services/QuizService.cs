using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class QuizService : IBaseQuizService
    {
        private readonly IUnitOfWork _database;
        public QuizService(IUnitOfWork uow)
        {
            _database = uow;
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
        }



        //public SubjectDTO Get(Guid id)
        //{
        //    Mapper.CreateMap<Subject, SubjectDTO>();
        //    return Mapper.Map<Subject, SubjectDTO>(Database.Subjects.Get(id));
        //}



        public void Dispose()
        {
            _database.Dispose();
        }


#pragma warning disable 618
        public IEnumerable<SubjectDto> GetAll()
        {
            Mapper.CreateMap<Theme, ThemeDto>();
            Mapper.CreateMap<Test, TestDto>();
            Mapper.CreateMap<Question, QuestionDto>();
            Mapper.CreateMap<Answer, AnswerDto>();
            Mapper.CreateMap<Subject, SubjectDto>();
            return Mapper.Map<IEnumerable<Subject>, List<SubjectDto>>(_database.Subjects.GetAll());
        }

        public TestDto Get(int id)
        {
            Mapper.CreateMap<Theme, ThemeDto>();
            Mapper.CreateMap<Test, TestDto>();
            return Mapper.Map<Test, TestDto>(_database.Tests.Get(id));
        }
#pragma warning restore 618

        public void AddStudentAnswer(StudentAnswerDto studentAnswer)
        {
            StudentAnswer answer = new StudentAnswer()
            {
                StudentAnswerId = studentAnswer.StudentAnswerId,
                Answer = _database.Answers.Get(studentAnswer.AnswerId),
                Question = _database.Questions.Get(studentAnswer.QuestionId),
                //User = Database.Users.Get(studentAnswer.UserId) ?? why error?
            };
            _database.StudentAnswers.Create(answer);
        }
    }
}
