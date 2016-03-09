using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public AnswerService(IUnitOfWork database)
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


        public IEnumerable<AnswerDto> GetAnswers(int questionId)
        {
            return _mapper.Map<IEnumerable<Answer>, List<AnswerDto>>(_database.Answers.GetAll().Where(x => x.Question.QuestionId == questionId));
        }

        public AnswerDto GetAnswer(int id)
        {
            return _mapper.Map<Answer, AnswerDto>(_database.Answers.Get(id));
        }

        public void AddAnswer(AnswerDto answer)
        {
            var addAnswer = _mapper.Map<AnswerDto, Answer>(answer);
            addAnswer.Question = _database.Questions.Get(answer.AnswerId);
            _database.Answers.Create(addAnswer);
            _database.Save();
        }

        public void DeleteAnswer(int id)
        {
            _database.Answers.Delete(id);
            _database.Save();
        }

        public void EditAnswer(AnswerDto test)
        {
            var newAnswer = _mapper.Map<AnswerDto, Answer>(test);
            _database.Answers.Update(newAnswer);
            _database.Save();
        }
    }
}
