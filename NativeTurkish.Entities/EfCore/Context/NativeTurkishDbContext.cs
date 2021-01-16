using Microsoft.EntityFrameworkCore;
using NativeTurkish.Entities.Concrete;
using NativeTurkish.Entities.EfCore.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTurkish.Entities.EfCore.Context
{
    public class NativeTurkishDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NDB2B06\\SQLEXPRESS; Database=NativeTurkish;uid=sa;pwd=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new LevelMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new QuestionChoicesMap());
            modelBuilder.ApplyConfiguration(new UserQuestionAnswerMap());
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoices> QuestionChoices { get; set; }
        public DbSet<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}
