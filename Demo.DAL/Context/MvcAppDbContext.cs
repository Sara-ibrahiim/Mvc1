using Demo.DAL.Enitities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class MvcAppDbContext : IdentityDbContext<ApplicationUser , ApplicationRole , string> 
    {
        public MvcAppDbContext(DbContextOptions <MvcAppDbContext> options) : base(options)
        {
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // optionsBuilder.UseSqlServer("server=.;database=MVCAppDb01; integrated security=true;");
          //  base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(x => x.Name);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
