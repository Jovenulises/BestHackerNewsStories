using BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces;
using BestHackerNewsStories.Architecture.HackerNewsStories.Models;
using Microsoft.Extensions.Caching.Memory;


namespace BestHackerNewsStories.Architecture.HackerNewsStories.Services
{

    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _repository;
        private readonly IMemoryCache _cache;

        public StoryService(IStoryRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<IEnumerable<Story>> GetTopBestStoriesAsync(int n)
        {
            string cacheKey = $"top_stories_{n}";

            if (_cache.TryGetValue(cacheKey, out IEnumerable<Story> cachedStories))
            {
                return cachedStories;
            }

            var ids = await _repository.GetBestStoryIdsAsync();
            var tasks = ids.Take(n).Select(id => _repository.GetStoryByIdAsync(id));
            var dtos = await Task.WhenAll(tasks);

            var stories = dtos
                .Where(s => s != null)
                .Select(s => new Story
                {
                    Title = s!.title ?? "",
                    Uri = s.url,
                    PostedBy = s.by ?? "",
                    Time = DateTimeOffset.FromUnixTimeSeconds(s.time).ToString("o"),
                    Score = s.score,
                    CommentCount = s.descendants
                })
                .OrderByDescending(s => s.Score)
                .ToList();

            // Guardar en caché por 5 minutos
            _cache.Set(cacheKey, stories, TimeSpan.FromMinutes(5));

            return stories;
        }
    }

}
