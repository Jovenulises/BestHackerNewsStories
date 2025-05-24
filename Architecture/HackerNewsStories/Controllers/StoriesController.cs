using BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BestHackerNewsStories.Architecture.HackerNewsStories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet("best-stories")]
        public async Task<IActionResult> GetBestStories([FromQuery] int n = 10)
        {
            var stories = await _storyService.GetTopBestStoriesAsync(n);
            return Ok(stories);
        }
    }
}
