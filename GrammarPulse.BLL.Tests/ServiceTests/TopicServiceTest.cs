using AutoMapper;
using Bogus;
using FluentAssertions;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.BLL.Services;
using GrammarPulse.Infrasructure.Mapping;
using Moq;

namespace GrammarPulse.BLL.Tests.ServiceTests;

public class TopicServiceTest
{
    private Mock<ITopicRepository> topicRepositoryMock = new Mock<ITopicRepository>();
    private Mock<IVersionRepository> versionRepositoryMock = new Mock<IVersionRepository>();

    private IMapper CreateTopicMapper()
    {
        var myProfile = new TopicProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        return new Mapper(configuration);
    }

    [Fact]
    public async Task GetByLevelId_ValidMappedTopics_ReturnsCorrectMappedTopics()
    {
        IMapper mapper = CreateTopicMapper();

        var topicFaker = new Faker<Topic>()
            .RuleFor(t => t.Name, f => f.Lorem.Text());
        var topics = topicFaker.Generate(5).AsEnumerable();

        topicRepositoryMock.Setup(m => m.GetByLevelIdAsync(It.IsAny<int>()).Result).Returns(topics);

        var topicService = new TopicService(mapper, topicRepositoryMock.Object, versionRepositoryMock.Object);
        var topicsFromService = await topicService.GetByLevelIdAsync(1);

        topicsFromService.Should().NotBeNull().And.HaveCountGreaterThan(0);

        topicsFromService.FirstOrDefault().Name.Should().NotBeNull().And.BeSameAs(topics.FirstOrDefault().Name);
    }

    [Fact]
    public async Task GetById_ValidMappedTopic_ReturnsCorrectMappedTopic()
    {
        IMapper mapper = CreateTopicMapper();

        var topic = new Topic()
        {
            Name = "TestName",
            Content = "TestContent",
            LevelId = 1
        };
        var expectedTopic = new TopicDto("TestName", "TestContent", 1);

        topicRepositoryMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()).Result).Returns(topic);

        var topicService = new TopicService(mapper, topicRepositoryMock.Object, versionRepositoryMock.Object);
        var topicFromService = await topicService.GetByIdAsync(1);

        topicFromService.Should().NotBeNull();
        topicFromService.Name.Should().NotBeNull().And.BeSameAs(topic.Name);
    }


}