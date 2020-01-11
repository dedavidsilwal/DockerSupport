using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DockerSupport
{

    class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "test", Address = "test" });

            base.OnModelCreating(modelBuilder);
        }

    }
}