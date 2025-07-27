namespace Coach2Go.Shared.Dtos
{
    public class DiaryEntryDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<string> Goals { get; set; } = new();
        public string? Note { get; set; }
        public string? Mood { get; set; }
        public int StreakPercent { get; set; }
    }
}