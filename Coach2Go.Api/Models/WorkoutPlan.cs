namespace Coach2Go.Api.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }

        public string Goal { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public int Duration { get; set; }  
        public string Intensity { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<WorkoutSession> Sessions { get; set; } = new();
    }
}
