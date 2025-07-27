namespace Coach2Go.Shared.Dtos
{
    public class AchievementDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime AchievedOn { get; set; }
    }
}