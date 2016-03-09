using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SubjectService : ISubjectService
    {
         private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Subject, SubjectDto>();
                cfg.CreateMap<SubjectDto, Subject>();

                cfg.CreateMap<Test, TestDto>();
                cfg.CreateMap<TestDto, Test>();

                cfg.CreateMap<QuestionDto, Question>();
                cfg.CreateMap<Question, QuestionDto>();

                cfg.CreateMap<Theme, ThemeDto>();
                cfg.CreateMap<ThemeDto, Theme>();

                cfg.CreateMap<AnswerDto, Answer>();
                cfg.CreateMap<Answer, AnswerDto>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<SubjectDto> GetSubjects()
        {
            return _mapper.Map<IEnumerable<Subject>, List<SubjectDto>>(_database.Subjects.GetAll());
        }

        public SubjectDto GetSubject(int id)
        {
            return _mapper.Map<Subject, SubjectDto>(_database.Subjects.Get(id));
        }

        public void AddSubject(SubjectDto subject)
        {
            var addsubject = _mapper.Map<SubjectDto, Subject>(subject);
            _database.Subjects.Create(addsubject);
            _database.Save();
        }

        public void DeleteSubject(int id)
        {
            _database.Subjects.Delete(id);
            _database.Save();
        }

        public void EditSubject(SubjectDto subject)
        {
            var newSubject = _mapper.Map<SubjectDto, Subject>(subject);
            _database.Subjects.Update(newSubject);
            _database.Save();
        }
    }
}
