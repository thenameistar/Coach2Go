namespace Coach2Go.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = default!;

        public string Email { get; set; } = default!;

        public List<WorkoutPlan> Plans { get; set; } = new(); // ensures it's never null
    }
}