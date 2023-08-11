using AutoMapper;
using Bogus;
using FluentAssertions;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.BLL.Services;
using GrammarPulse.Infrasructure.Mapping;
using Moq;

namespace GrammarPulse.BLL.Tests.ServiceTests;

public class ExerciseserviceTest
{
    private Mock<IExerciseRepository> exerciseRepositoryMock = new Mock<IExerciseRepository>();

    private IMapper CreateExerciseMapper()
    {
        var myProfile = new ExerciseProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        return new Mapper(configuration);
    }

    [Fact]
    public async Task GetByTopicId_ValidMappedExercises_ReturnsCorrectMappedExercises()
    {
        IMapper mapper = CreateExerciseMapper();

        var exerciseFaker = new Faker<Exercise>()
            .RuleFor(e => e.EnglishValue, f => f.Lorem.Sentence());
        var exercises = exerciseFaker.Generate(5).AsEnumerable();

        exerciseRepositoryMock.Setup(m => m.GetByTopicIdAsync(It.IsAny<int>()).Result).Returns(exercises);

        var exerciseService = new ExerciseService(mapper, exerciseRepositoryMock.Object);
        var exercisesFromService = await exerciseService.GetByTopicIdAsync(1);

        exercisesFromService.Should().NotBeNull().And.HaveCountGreaterThan(0);
        exercisesFromService.FirstOrDefault().EnglishValue.Should().NotBeNull().And.BeSameAs(exercises.FirstOrDefault().EnglishValue);
    }

}
