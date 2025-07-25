using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Coach2Go.Api.Services
{
    public class OpenAiService : IAiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public OpenAiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GenerateWorkouts(string prompt)
        {
            var apiKey = _config["OpenAI:ApiKey"];
            var endpoint = "https://api.openai.com/v1/chat/completions";

            var body = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are a fitness assistant." },
                    new { role = "user", content = prompt }
                },
                max_tokens = 1000,
                temperature = 0.7
            };

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var parsed = JsonSerializer.Deserialize<OpenAiResponse>(json);

            if (parsed?.choices == null || parsed.choices.Count == 0)
                throw new Exception("Invalid AI response");

            return parsed.choices[0].message.content;
        }

        private class OpenAiResponse
        {
            public List<Choice> choices { get; set; } = new();
        }

        private class Choice
        {
            public Message message { get; set; } = new();
        }

        private class Message
        {
            public string role { get; set; } = string.Empty;
            public string content { get; set; } = string.Empty;
        }
    }
}