using AutoMapper;
using Bogus;
using FluentAssertions;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.BLL.Services;
using GrammarPulse.Infrasructure;
using Moq;

namespace GrammarPulse.BLL.Tests.ServiceTests;

public class LevelServiceTest
{
    private Mock<ILevelRepository> levelRepositoryMock = new Mock<ILevelRepository>();

    private IMapper CreateLevelMapper()
    {
        var myProfile = new LevelProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        return new Mapper(configuration);
    }

    [Fact]
    public async Task GetAll_ValidMappedLevels_ReturnsCorrectMappedLevels()
    {
        IMapper mapper = CreateLevelMapper();

        var levelFaker = new Faker<Level>()
            .RuleFor(l => l.Name, f => f.Hacker.Adjective());
        var levels = levelFaker.Generate(5).AsEnumerable();

        levelRepositoryMock.Setup(m => m.GetAllAsync().Result).Returns(levels);

        var levelService = new LevelService(mapper, levelRepositoryMock.Object);
        var levelsFromService = await levelService.GetAllAsync();

        levelsFromService.Should().NotBeNull().And.HaveCountGreaterThan(0);

        levelsFromService.FirstOrDefault().Name.Should().NotBeNull().And.BeSameAs(levels.FirstOrDefault().Name);
    }

    [Fact]
    public async Task Add_ValidMappedLevel_RepositoryMethodAddIsCalledOnce()
    {
        IMapper mapper = CreateLevelMapper();
        levelRepositoryMock.Setup(m => m.AddAsync(It.IsAny<Level>()).Result).Returns(1);

        var newLevelDto = new LevelDto("TestCode", "Test");

        var levelService = new LevelService(mapper, levelRepositoryMock.Object);
        var newLevelId = await levelService.AddAsync(newLevelDto);

        newLevelId.Should().BeGreaterThan(0);

        levelRepositoryMock.Verify(m => m.AddAsync(It.IsAny<Level>()), Times.Once); ;
    }

    [Fact]
    public async Task Update_ValidMappedLevel_RepositoryMethodUpdateIsCalledOnce()
    {
        IMapper mapper = CreateLevelMapper();

        var newLevelDto = new LevelDto("TestCode", "Test") { Id = 1 };

        var levelService = new LevelService(mapper, levelRepositoryMock.Object);
        await levelService.UpdateAsync(newLevelDto);

        levelRepositoryMock.Verify(m => m.UpdateAsync(It.IsAny<Level>()), Times.Once); ;
    }

    [Fact]
    public async Task Delete_ValidId_RepositoryMethodDeleteIsCalledOnce()
    {
        IMapper mapper = CreateLevelMapper();

        var levelService = new LevelService(mapper, levelRepositoryMock.Object);
        await levelService.DeleteAsync(1);

        levelRepositoryMock.Verify(m => m.DeleteAsync(It.IsAny<int>()), Times.Once); ;
    }
}