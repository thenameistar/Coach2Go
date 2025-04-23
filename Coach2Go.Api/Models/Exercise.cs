namespace Coach2Go.Api.Models
{
    public class Exercise
    { public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

    public int WorkoutSessionId { get; set; }
    public WorkoutSession WorkoutSession { get; set; } = default!;
    }
}