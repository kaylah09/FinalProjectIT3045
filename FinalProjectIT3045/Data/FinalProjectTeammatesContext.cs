using FinalProjectIT3045.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIT3045.Data
{
    public class FinalProjectTeammatesContext : DbContext
    {
        public FinalProjectTeammatesContext(DbContextOptions<FinalProjectTeammatesContext> options) : base(options) { }

        public DbSet<CollegeCourse> CollegeCourses { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CollegeCourse>().HasData( 
                new CollegeCourse { Id = 1, Subject = "IT", CourseName = "Contemporary Programming", StartDate = new DateOnly(2026, 05, 11), EndDate = new DateOnly(2026, 08, 08), ProfessorFirst = "Dyllon", ProfessorLast = "Dekok" },
                new CollegeCourse { Id = 2, Subject = "Math", CourseName = "Applied Statistics for Human Services", StartDate = new DateOnly(2026, 05, 11), EndDate = new DateOnly(2026, 08, 08), ProfessorFirst = "Samuel", ProfessorLast = "Adabla" },
                new CollegeCourse { Id = 3, Subject = "IT", CourseName = "Human Computer Interaction", StartDate = new DateOnly(2026, 05, 11), EndDate = new DateOnly(2026, 08, 08), ProfessorFirst = "Theodore", ProfessorLast = "Langdon" },
                new CollegeCourse { Id = 4, Subject = "IT", CourseName = "Web Game Development", StartDate = new DateOnly(2026, 05, 11), EndDate = new DateOnly(2026, 08, 08), ProfessorFirst = "Andrew", ProfessorLast = "Lively" }
                //Zoe - Feel free to add any courses you are taking here, if you want!
            );

            builder.Entity<Pet>().HasData(
                new Pet { Id = 1, Species = "Dog", Breed = "Husky", Name = "Jacob", DateOfBirth = null },
                new Pet { Id = 2, Species = "Dog", Breed = "Chihuahua", Name = "Brandy", DateOfBirth = null }
                //Zoe - Feel free to add any pets you might have here!
            );
        }
    }
}
