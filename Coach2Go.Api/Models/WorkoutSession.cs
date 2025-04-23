namespace Coach2Go.Api.Models
{
    public class WorkoutSession
    { public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Week { get; set; } 

    public int WorkoutPlanId { get; set; }
    public WorkoutPlan WorkoutPlan { get; set; } = default!;

    public List<Exercise> Exercises { get; set; } = new();
    }
}