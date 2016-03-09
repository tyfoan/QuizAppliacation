using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class QuizContext : DbContext
    {
        public DbSet<Role>  Roles { get; set; }
        public DbSet<User>  Users { get; set; }
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
        //static QuizContext()
        //{
        //    Database.SetInitializer(new QuizDbInitializer());
        //}
    }
}
