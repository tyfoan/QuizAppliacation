using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.EF
{
    public class QuizContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }

        public QuizContext()
            : base("QuizDB")
        {

        }
        static QuizContext()
        {
            Database.SetInitializer<QuizContext>(new QuizDBInitializer());
        }
    }
}
