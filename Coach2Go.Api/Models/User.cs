using System.ComponentModel.DataAnnotations.Schema;

namespace Coach2Go.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;

<<<<<<< HEAD
        public string? GoogleId { get; set; } 

        public string Goal { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;

        public int? WorkoutPlanId { get; set; }

        [ForeignKey("WorkoutPlanId")]
        public WorkoutPlan? WorkoutPlan { get; set; }
=======
        public List<WorkoutPlan> Plans { get; set; } = new(); 
>>>>>>> e02b59bb5928a45dfbb571013add94516414e195
    }
}
