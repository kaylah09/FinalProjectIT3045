using FinalProjectIT3045.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIT3045.Data
{
    public class FinalProjectTeammatesContext : DbContext
    {
        public FinalProjectTeammatesContext(DbContextOptions<FinalProjectTeammatesContext> options) : base(options) { }

        public DbSet<CollegeCourse> CollegeCourses { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
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
                new Pet { Id = 2, Species = "Dog", Breed = "Chihuahua", Name = "Brandy", DateOfBirth = null },
                new Pet { Id = 3, Species = "cat", Breed = "DSH", Name = "Dice", DateOfBirth = new DateOnly(2023, 05, 20) }
                //Zoe - Feel free to add any pets you might have here!
            );
            builder.Entity<FavoriteBook>().HasData(
                new FavoriteBook { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", PublicationDate = new DateTime(1925, 04, 10) },
                new FavoriteBook { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", PublicationDate = new DateTime(1960, 7, 11) },
                new FavoriteBook { Id = 3, Title = "1984", Author = "George Orwell", Genre = "Dystopian", PublicationDate = new DateTime(1948, 06, 8) }
                // Add more favorite books as needed
            );
            builder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FirstName = "Kaylah", LastName = "Hammond", CollegeProgram = "Information Technology", YearInProgram = "Senior" , DateOfBirth = new DateTime(2003, 09, 02) },
                new TeamMember { Id = 2, FirstName = "Zoe", LastName = "Aspenns", DateOfBirth = new DateTime(2006, 09, 25), CollegeProgram = "Information Technology", YearInProgram = "Sophomore" }
                // Add more team members as needed
            );
        }
    }
}
