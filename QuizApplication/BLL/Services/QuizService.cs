using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class QuizService : IBaseQuizService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public QuizService(IUnitOfWork uow)
        {
            _database = uow;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Answer, AnswerDto>();
                cfg.CreateMap<AnswerDto, Answer>();

                cfg.CreateMap<StudentAnswer, StudentAnswerDto>();
                cfg.CreateMap<StudentAnswerDto, StudentAnswer>();

                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<QuestionDto, Question>();

                cfg.CreateMap<Test, TestDto>();
                cfg.CreateMap<TestDto, Test>();

                cfg.CreateMap<Subject, SubjectDto>();
                cfg.CreateMap<SubjectDto, Subject>();

                cfg.CreateMap<Theme, ThemeDto>();
                cfg.CreateMap<ThemeDto, Theme>();
            });
            _mapper = config.CreateMapper();
        }
        
        public void Dispose()
        {
            _database.Dispose();
        }


        public IEnumerable<SubjectDto> GetAll()
        {
            //Mapper.CreateMap<Theme, ThemeDto>();
            //Mapper.CreateMap<Test, TestDto>();
            //Mapper.CreateMap<Question, QuestionDto>();
            //Mapper.CreateMap<Answer, AnswerDto>();
            //Mapper.CreateMap<Subject, SubjectDto>();

            return _mapper.Map<IEnumerable<Subject>, List<SubjectDto>>(_database.Subjects.GetAll());
        }

        public TestDto Get(int id)
        {
            return _mapper.Map<Test, TestDto>(_database.Tests.Get(id));
        }

        public void AddStudentAnswer(StudentAnswerDto studentAnswer)
        {
            StudentAnswer answer = new StudentAnswer()
            { 
                StudentAnswerId = studentAnswer.StudentAnswerGuid,
                Answer = _database.Answers.Get(studentAnswer.AnswerId),
                Question = _database.Questions.Get(studentAnswer.QuestionId),
                User = _database.Users.Get(studentAnswer.UserId)
            };
            _database.StudentAnswers.Create(answer);
            _database.Save();
        }

        public double Estimate(int userId, int question)
        {
            IEnumerable<StudentAnswer> studentAnswer = _database.StudentAnswers.GetAll()
                .Where(x => x.User.UserId == userId);
            foreach (var answer in studentAnswer)
            {
                
            }

            return 100.0;
        }

        public StudentAnswerDto GetStudentAnswer()
        {
            return new StudentAnswerDto();
        }
    }
}
