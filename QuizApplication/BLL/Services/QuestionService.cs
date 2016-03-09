using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<QuestionDto, Question>();

                cfg.CreateMap<QuestionDto, Question>();
                cfg.CreateMap<Question, QuestionDto>();

                cfg.CreateMap<Theme, ThemeDto>();
                cfg.CreateMap<ThemeDto, Theme>();

                cfg.CreateMap<AnswerDto, Answer>();
                cfg.CreateMap<Answer, AnswerDto>();
            });
            _mapper = config.CreateMapper();
        }


        public IEnumerable<QuestionDto> GetQuestions(int testId)
        {
            return _mapper.Map<IEnumerable<Question>, List<QuestionDto>>(_database.Questions.GetAll().Where(x=>x.Test.TestId == testId));
        }

        public QuestionDto GetQuestion(int id)
        {
            return _mapper.Map<Question, QuestionDto>(_database.Questions.Get(id));
        }

        public void AddQuestion(QuestionDto question)
        {
            var addQuestion = _mapper.Map<QuestionDto, Question>(question);
            addQuestion.Test = _database.Tests.Get(question.TestId);
            _database.Questions.Create(addQuestion);
            _database.Save();
        }

        public void DeleteQuestion(int id)
        {
            _database.Questions.Delete(id);
            _database.Save();
        }

        public void EditQuestion(QuestionDto question)
        {
            var newQuestion = _mapper.Map<QuestionDto, Question>(question);
            _database.Questions.Update(newQuestion);
            _database.Save();
        }
    }
}
