namespace FinalProjectIT3045.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public required string Species { get; set; }

        public string? Breed { get; set; }

        public required string Name { get; set; }

        public DateOnly? DateOfBirth { get; set; }
    }
}
