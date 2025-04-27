namespace Coach2Go.Shared.Dtos
{
    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        public string Goal { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Intensity { get; set; } = string.Empty;
        public List<WorkoutSessionDto> Sessions { get; set; } = new();
    }

   public class WorkoutSessionDto
   {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int Duration { get; set; } 
        public string Day { get; set; } = string.Empty; 
        public int Week { get; set; }
        public List<ExerciseDto> Exercises { get; set; } = new(); // ✅
    }

    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Details { get; set; } = "";
        public string ImagePath { get; set; } = "";
    }
}