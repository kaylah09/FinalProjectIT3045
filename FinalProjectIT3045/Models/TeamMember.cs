namespace FinalProjectIT3045.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public  DateTime DateOfBirth { get; set; }
        public required string CollegeProgram { get; set; } = string.Empty;
        public required string YearInProgram { get; set; } = string.Empty;
    }
}
