namespace Coach2Go.Api.Services
{
    public interface IAiService
    {
        Task<string> GenerateWorkouts(string prompt);
    }
}