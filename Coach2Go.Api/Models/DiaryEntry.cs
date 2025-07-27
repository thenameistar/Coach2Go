using System.ComponentModel.DataAnnotations;

namespace Coach2Go.Api.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public List<string>? Goals { get; set; }

        public string? Note { get; set; }

        public string? Mood { get; set; }

        public int StreakPercent { get; set; }
    }
}