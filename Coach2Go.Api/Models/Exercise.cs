namespace Coach2Go.Api.Models
{
    public class Exercise
    {
        public int Id { get; set; } // ✅ Primary key

        public string Name { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string RepsOrDuration { get; set; } = default!;

        // Foreign key reference to WorkoutPlan
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = default!;
    }
}