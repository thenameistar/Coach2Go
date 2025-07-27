namespace Coach2Go.Shared.Dtos
{
    public class WorkoutPreferencesDto
    {
        public string Type { get; set; } = string.Empty;
        public int Time { get; set; }
        public string Goal { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty; 
        public string? Experience { get; set; } 
         public bool EnableAI { get; set; } 
}
}