namespace Coach2Go.Shared.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? WorkoutPlanId { get; set; }
    }
}