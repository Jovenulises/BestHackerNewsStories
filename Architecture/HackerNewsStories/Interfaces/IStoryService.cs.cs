using BestHackerNewsStories.Architecture.HackerNewsStories.Models;

namespace BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<Story>> GetTopBestStoriesAsync(int n);
    }
}
