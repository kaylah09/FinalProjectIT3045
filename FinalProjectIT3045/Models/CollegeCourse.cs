namespace FinalProjectIT3045.Models
{
    public class CollegeCourse
    {
        public int Id { get; set; }

        public required string Subject { get; set; }

        public required string CourseName { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public required string ProfessorFirst { get; set; }

        public required string ProfessorLast { get; set; }
    }
}
