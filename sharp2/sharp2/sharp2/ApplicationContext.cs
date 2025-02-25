using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sharp2.Entities;


namespace sharp2
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Grades> grades => Set<Grades>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=B:\\вуз\\0_Академия\\Академия 3 курс\\sharp\\sharp2\\LastLab.db");
        }
    }
}
