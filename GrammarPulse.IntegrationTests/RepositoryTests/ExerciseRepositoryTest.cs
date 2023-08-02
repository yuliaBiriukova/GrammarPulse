using FluentAssertions;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Enums;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using GrammarPulse.DAL.Repositories;
using GrammarPulse.IntegrationTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GrammarPulse.IntegrationTests.RepositoryTests;

public class ExerciseRepositoryTest : IAsyncLifetime
{
    private GrammarPulseDbContext _dbContext { get; set; }
    private readonly IServiceScopeFactory _scopeFactory;
    private IExerciseRepository _exerciseRepository;

    public ExerciseRepositoryTest()
    {
        _dbContext = DbUtilities.GetGrammarPulseDbContext("GrammarPulseDb");

        var services = new ServiceCollection();
        services.AddSingleton(_dbContext);
        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        var provider = services.BuildServiceProvider();
        _scopeFactory = provider.GetService<IServiceScopeFactory>();
    }

    public async Task InitializeAsync()
    {
        var scope = _scopeFactory.CreateScope();
        _exerciseRepository = scope.ServiceProvider.GetService<IExerciseRepository>();
        await CreateSeedData();
    }

    public async Task DisposeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.DisposeAsync();
    }

    private async Task CreateSeedData()
    {
        await SeedExercises();
    }

    private async Task SeedExercises()
    {
        _dbContext.Exercises.AddRange(
            new Exercise 
            { 
                Id = 1, 
                Type = ExerciseType.Translation, 
                UkrainianValue = "Вправа 1",
                EnglishValue = "Exercise 1",
                TopicId = 1 
            },
            new Exercise
            {
                Id = 2,
                Type = ExerciseType.Translation,
                UkrainianValue = "Вправа 2",
                EnglishValue = "Exercise 3",
                TopicId = 1
            });
        await _dbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task Should_Return_Exercises_By_Topic_Id()
    {
        var topicId = 1;
        var exercises = await _exerciseRepository.GetByTopicIdAsync(topicId);

        exercises.Should().NotBeNull().And.HaveCount(2).And.OnlyContain(e => e.TopicId == topicId);
    }

    [Fact]
    public async Task Should_Add_New_Exercise()
    {
        var exerciseToAdd = new Exercise
        {
            Type = ExerciseType.Translation,
            UkrainianValue = "Вправа 3",
            EnglishValue = "Exercise 3",
            TopicId = 1
        };

        var newExerciseId = await _exerciseRepository.AddAsync(exerciseToAdd);
        var addedExercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == 3);

        newExerciseId.Should().Be(3);
        addedExercise.Should().NotBeNull();
        addedExercise.Id.Should().Be(newExerciseId);
    }

    [Fact]
    public async Task Should_Update_Exercise()
    {
        var exerciseToUpdate = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == 1);
        exerciseToUpdate.EnglishValue = "Exercise 1 updated";

        await _exerciseRepository.UpdateAsync(exerciseToUpdate);
        var updatedExercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseToUpdate.Id);

        updatedExercise.Should().NotBeNull().And.BeSameAs(exerciseToUpdate);
    }

    [Fact]
    public async Task Should_Delete_Exercise_By_Id()
    {
        var exerciseIdToDelete = 1;

        await _exerciseRepository.DeleteAsync(exerciseIdToDelete);
        var deletedExercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseIdToDelete);

        deletedExercise.Should().BeNull();
    }
}