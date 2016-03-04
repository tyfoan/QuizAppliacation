using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    class ThemeRepository: IRepository<Theme>
    {
        private readonly QuizContext _db;
        public ThemeRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Theme> GetAll()
        {
            return _db.Themes;
        }

        public Theme Get(Guid id)
        {
            return _db.Themes.Find(id);
        }

        public void Create(Theme item)
        {
            _db.Themes.Add(item);
        }

        public void Update(Theme item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Theme theme = _db.Themes.Find(id);
            if (theme != null)
            {
                _db.Themes.Remove(theme);
            }
        }
    }
}
