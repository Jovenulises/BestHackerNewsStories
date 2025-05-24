using BestHackerNewsStories.Architecture.HackerNewsStories.Config;
using BestHackerNewsStories.Architecture.HackerNewsStories.DTOs;
using BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BestHackerNewsStories.Architecture.HackerNewsStories.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public StoryRepository(IHttpClientFactory httpClientFactory, IOptions<HackerNewsOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _baseUrl = options.Value.BaseUrl;
        }

        public async Task<List<int>> GetBestStoryIdsAsync()
        {
            var json = await _httpClient.GetStringAsync($"{_baseUrl}/beststories.json");
            return JsonSerializer.Deserialize<List<int>>(json)!;
        }

        public async Task<StoryDto?> GetStoryByIdAsync(int id)
        {
            var json = await _httpClient.GetStringAsync($"{_baseUrl}/item/{id}.json");
            return JsonSerializer.Deserialize<StoryDto>(json);
        }
    }
}
