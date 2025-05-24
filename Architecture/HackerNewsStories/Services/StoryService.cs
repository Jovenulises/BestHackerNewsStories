using BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces;
using BestHackerNewsStories.Architecture.HackerNewsStories.Models;


namespace BestHackerNewsStories.Architecture.HackerNewsStories.Services
{

    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _repository;

        public StoryService(IStoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Story>> GetTopBestStoriesAsync(int n)
        {
            var ids = await _repository.GetBestStoryIdsAsync();
            var tasks = ids.Take(n).Select(id => _repository.GetStoryByIdAsync(id));
            var dtos = await Task.WhenAll(tasks);

            return dtos
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
                .OrderByDescending(s => s.Score);
        }
    }
}
