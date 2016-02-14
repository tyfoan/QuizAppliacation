using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class QuizService : IBaseQuizService
    {
        IUnitOfWork Database { get; set; }
        public QuizService(IUnitOfWork uow)
        {
            Database = uow;
        }



        public SubjectDTO Get(Guid id)
        {
            Mapper.CreateMap<Subject, SubjectDTO>();
            return Mapper.Map<Subject, SubjectDTO>(Database.Subjects.Get(id));
        }



        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SubjectDTO> GetAll()
        {
            Mapper.CreateMap<Subject, SubjectDTO>();
            return Mapper.Map<IEnumerable<Subject>, List<SubjectDTO>>(Database.Subjects.GetAll());
        }
    }
}
