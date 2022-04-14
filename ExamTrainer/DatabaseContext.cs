using ExamTrainer.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamTrainer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Exam> Exams { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Anwser> Anwsers { get; set; }


        public string DbPath { get; }

        
        public DatabaseContext(DbContextOptions options) : base(options) { }

    }
}
