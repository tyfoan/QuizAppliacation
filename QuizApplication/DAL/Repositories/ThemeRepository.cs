using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ThemeRepository: IRepository<Theme>
    {
        private QuizContext db;
        public ThemeRepository(QuizContext context)
        {
            this.db = context;
        }

        public IEnumerable<Theme> GetAll()
        {
            return db.Themes;
        }

        public Theme Get(Guid id)
        {
            return db.Themes.Find(id);
        }

        public void Create(Theme item)
        {
            db.Themes.Add(item);
        }

        public void Update(Theme item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Theme theme = db.Themes.Find(id);
            if (theme != null)
            {
                db.Themes.Remove(theme);
            }
        }
    }
}
