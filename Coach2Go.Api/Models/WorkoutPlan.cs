namespace Coach2Go.Api.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }

        public string Goal { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public int Duration { get; set; }  // in minutes
        public string Intensity { get; set; } = string.Empty;

        // If you're assigning to user onboarding, keep this
        public int? UserId { get; set; }
        public User? User { get; set; }

        // Change this: a plan now contains sessions
        public List<WorkoutSession> Sessions { get; set; } = new();
    }
}
