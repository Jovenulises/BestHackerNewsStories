using BestHackerNewsStories.Architecture.HackerNewsStories.Config;
using BestHackerNewsStories.Architecture.HackerNewsStories.Interfaces;
using BestHackerNewsStories.Architecture.HackerNewsStories.Repositories;
using BestHackerNewsStories.Architecture.HackerNewsStories.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.Configure<HackerNewsOptions>(
builder.Configuration.GetSection("HackerNews"));
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://fronthacker-btgwavg2cfgubgd6.mexicocentral-01.azurewebsites.net")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddMemoryCache();



var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
