namespace Coach2Go.Api.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; } // ✅ Primary key

        public string Goal { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Experience { get; set; } = default!;

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        // Navigation to Exercises
        public List<Exercise> Exercises { get; set; } = new();
    }
}