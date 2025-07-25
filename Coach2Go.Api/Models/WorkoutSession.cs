namespace Coach2Go.Api.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Week { get; set; } 
        public string Day { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int Duration { get; set; } 
        public string Category { get; set; } = string.Empty;
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = default!;
        public List<Exercise> Exercises { get; set; } = new();
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? UserId { get; set; }          
        public User? User { get; set; }   
        public string? TargetMuscles { get; set; }
        public string? Level { get; set; }
        public string? Equipment { get; set; }
        public string Type { get; set; } = string.Empty;

    }
}