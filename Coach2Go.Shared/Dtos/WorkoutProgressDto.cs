namespace Coach2Go.Shared.Dtos
{
    public class WorkoutProgressDto
    {
        public string SessionTitle { get; set; } = string.Empty;
        public int Sets { get; set; }
        public DateTime Date { get; set; }
    }
}