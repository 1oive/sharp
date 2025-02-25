using Microsoft.EntityFrameworkCore;
using entity.Entities; 

namespace entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=B:\\вуз\\0_Академия\\Академия 3 курс\\sharp\\sharp2\\LastLab.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///<summary>
            ///Модель подразделения. У него много пользователей
            ///</summary>
            modelBuilder.Entity<Student>((c) => {
                c.HasMany(d => d.Grades)
                .WithOne(d => d.Student)
                .HasForeignKey(c => c.StudentId);
            });
        }
    }

}
