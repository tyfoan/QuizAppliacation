using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public TestService(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg =>
            {
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


        public IEnumerable<TestDto> GetTests(int subjId)
        {
            return _mapper.Map<IEnumerable<Test>, List<TestDto>>(_database.Tests.GetAll().Where(x=>x.Subject.SubjectId == subjId));
        }

        public TestDto GetTest(int id)
        {
            return _mapper.Map<Test, TestDto>(_database.Tests.Get(id));
        }

        public void AddTest(TestDto test)
        {
            var addTest = _mapper.Map<TestDto, Test>(test);
            addTest.Subject = _database.Subjects.Get(test.SubjectId);
            _database.Tests.Create(addTest);
            _database.Save();
        }

        public void DeleteTest(int id)
        {
            _database.Tests.Delete(id);
            _database.Save();
        }

        public void EditTest(TestDto newTest)
        {
            var EfTest = _database.Tests.Get(newTest.TestId);
            EfTest.Duration = newTest.Duration;
            EfTest.Complexity = newTest.Complexity;
            EfTest.Name = newTest.Name;
            //EfTest.Themes = newTest.Themes;
            _database.Save();
        }
    }
}
