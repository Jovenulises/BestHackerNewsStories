using BestHackerNewsStories.Architecture.HackerNewsStories.DTOs;

namespace BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces
{
    public interface IStoryRepository
    {
        Task<List<int>> GetBestStoryIdsAsync();
        Task<StoryDto?> GetStoryByIdAsync(int id);
    }
}
