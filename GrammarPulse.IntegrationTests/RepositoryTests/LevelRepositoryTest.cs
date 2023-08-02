using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using GrammarPulse.DAL.Repositories;
using GrammarPulse.IntegrationTests.Utilities;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.IntegrationTests.RepositoryTests;

public class LevelRepositoryTest : IAsyncLifetime
{
    private GrammarPulseDbContext _dbContext { get; set; }
    private readonly IServiceScopeFactory _scopeFactory;
    private ILevelRepository _levelRepository;

    public LevelRepositoryTest()
    {
        _dbContext = DbUtilities.GetGrammarPulseDbContext("GrammarPulseDb");

        var services = new ServiceCollection();
        services.AddSingleton(_dbContext);
        services.AddScoped<ILevelRepository, LevelRepository>();

        var provider = services.BuildServiceProvider();
        _scopeFactory = provider.GetService<IServiceScopeFactory>();
    }

    public async Task InitializeAsync()
    {
        var scope = _scopeFactory.CreateScope();
        _levelRepository = scope.ServiceProvider.GetService<ILevelRepository>();
        await CreateSeedData();
    }

    public async Task DisposeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.DisposeAsync();
    }

    private async Task CreateSeedData()
    {
        await SeedLevels();
    }

    private async Task SeedLevels()
    {
        _dbContext.Levels.AddRange(
            new Level { Id = 1, Code = "A1", Name = "Beginner" },
            new Level { Id = 2, Code = "A2", Name = "Pre-Intermediate" },
            new Level { Id = 3, Code = "B1", Name = "Intermediate" },
            new Level { Id = 4, Code = "B2", Name = "Upper-Intermediate" },
            new Level { Id = 5, Code = "C1", Name = "Advanced" },
            new Level { Id = 6, Code = "C2", Name = "Proficient" });
        await _dbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task Should_Return_Levels()
    {
        var levels = await _levelRepository.GetAllAsync();

        levels.Should().NotBeNull().And.HaveCount(6);
    }

    [Fact]
    public async Task Should_Add_New_Level()
    {
        var levelToAdd = new Level { Code = "Test", Name = "Test level" };

        var newLevelId = await _levelRepository.AddAsync(levelToAdd);
        var addedLevel = await _dbContext.Levels.FirstOrDefaultAsync(l => l.Id == 7);

        newLevelId.Should().Be(7);
        addedLevel.Should().NotBeNull();
        addedLevel.Id.Should().Be(newLevelId);
    }

    [Fact]
    public async Task Should_Update_Level()
    {
        var levelToUpdate = await _dbContext.Levels.FirstOrDefaultAsync(l => l.Id == 1);
        levelToUpdate.Name = "Elementary";

        await _levelRepository.UpdateAsync(levelToUpdate);
        var updatedLevel = await _dbContext.Levels.FirstOrDefaultAsync(l => l.Id == levelToUpdate.Id);

        updatedLevel.Should().NotBeNull().And.BeSameAs(levelToUpdate);
    }

    [Fact]
    public async Task Should_Delete_Level_By_Id()
    {
        var levelIdToDelete = 1;

        await _levelRepository.DeleteAsync(levelIdToDelete);
        var deletedLevel = await _dbContext.Levels.FirstOrDefaultAsync(l => l.Id == levelIdToDelete);

        deletedLevel.Should().BeNull();
    }
}