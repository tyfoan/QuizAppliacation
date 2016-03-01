using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.EF
{
    public class QuizContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Theme> Themes { get; set; }

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
