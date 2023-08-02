using FluentAssertions;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using GrammarPulse.DAL.Repositories;
using GrammarPulse.IntegrationTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GrammarPulse.IntegrationTests.RepositoryTests;

public class TopicRepositoryTest : IAsyncLifetime
{
    private GrammarPulseDbContext _dbContext { get; set; }
    private readonly IServiceScopeFactory _scopeFactory;
    private ITopicRepository _topicRepository;

    public TopicRepositoryTest()
    {
        _dbContext = DbUtilities.GetGrammarPulseDbContext("GrammarPulseDb");

        var services = new ServiceCollection();
        services.AddSingleton(_dbContext);
        services.AddScoped<ITopicRepository, TopicRepository>();

        var provider = services.BuildServiceProvider();
        _scopeFactory = provider.GetService<IServiceScopeFactory>();
    }

    public async Task InitializeAsync()
    {
        var scope = _scopeFactory.CreateScope();
        _topicRepository = scope.ServiceProvider.GetService<ITopicRepository>();
        await CreateSeedData();
    }

    public async Task DisposeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.DisposeAsync();
    }

    private async Task CreateSeedData()
    {
        await SeedTopics();
    }

    private async Task SeedTopics()
    {
        _dbContext.Topics.AddRange(
            new Topic { Id = 1, Name = "Topic 1", Content = "Topic 1 content", LevelId = 1 },
            new Topic { Id = 2, Name = "Topic 2", Content = "Topic 2 content", LevelId = 1 });
        await _dbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task Should_Return_Topics_By_Level_Id()
    {
        var levelId = 1;
        var topics = await _topicRepository.GetByLevelIdAsync(levelId);

        topics.Should().NotBeNull().And.HaveCount(2).And.OnlyContain(t => t.LevelId == levelId); ;
    }

    [Fact]
    public async Task Should_Return_Topic_By_Id()
    {
        var topicId = 1;
        var topic = await _dbContext.Topics.FirstOrDefaultAsync(t => t.Id == topicId);

        var topicFromRepo = await _topicRepository.GetByIdAsync(topicId);

        topicFromRepo.Should().NotBeNull().And.BeSameAs(topic);
    }

    [Fact]
    public async Task Should_Add_New_Topic()
    {
        var topicToAdd = new Topic { Name = "Topic 3", Content = "Topic 3 content", LevelId = 1 };

        var newTopicId = await _topicRepository.AddAsync(topicToAdd);
        var addedTopic = await _dbContext.Topics.FirstOrDefaultAsync(t => t.Id == 3);

        newTopicId.Should().Be(3);
        addedTopic.Should().NotBeNull();
        addedTopic.Id.Should().Be(newTopicId);
    }

    [Fact]
    public async Task Should_Update_Topic()
    {
        var topicToUpdate = await _dbContext.Topics.FirstOrDefaultAsync(t => t.Id == 1);
        topicToUpdate.Name = "Topic 1 updated";

        await _topicRepository.UpdateAsync(topicToUpdate);
        var updatedTopic = await _dbContext.Topics.FirstOrDefaultAsync(t => t.Id == topicToUpdate.Id);

        updatedTopic.Should().NotBeNull().And.BeSameAs(topicToUpdate);
    }

    [Fact]
    public async Task Should_Delete_Topic_By_Id()
    {
        var topicIdToDelete = 1;

        await _topicRepository.DeleteAsync(topicIdToDelete);
        var deletedTopic = await _dbContext.Topics.FirstOrDefaultAsync(t => t.Id == topicIdToDelete);

        deletedTopic.Should().BeNull();
    }

}
