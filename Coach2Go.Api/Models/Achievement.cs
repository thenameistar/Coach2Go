public class Achievement
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime AchievedOn { get; set; } = DateTime.UtcNow;
}