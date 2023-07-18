using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;

namespace GrammarPulse.BLL.Services;

public class TopicService : ITopicService
{
    private readonly IMapper _mapper;
    private readonly ITopicRepository _topicRepository;
    private readonly IVersionRepository _versionRepository;

    public TopicService(IMapper mapper, ITopicRepository topicRepository, IVersionRepository versionRepository)
    {
        _mapper = mapper;
        _topicRepository = topicRepository;
        _versionRepository = versionRepository;
    }

    public async Task<IEnumerable<TopicDto>> GetByLevelIdAsync(int levelId)
    {
        var topics = await _topicRepository.GetByLevelIdAsync(levelId);
        return _mapper.Map<IEnumerable<TopicDto>>(topics);
    }

    public async Task<TopicDto> GetByIdAsync(int id)
    {
        var topic = await _topicRepository.GetByIdAsync(id);
        return _mapper.Map<TopicDto>(topic);
    }

    public async Task<int> AddAsync(TopicDto topic)
    {
        var newTopic = _mapper.Map<Topic>(topic);
        newTopic.Versions = new List<VersionEntity> { await _versionRepository.GetByVersionAsync(1) };
        return await _topicRepository.AddAsync(newTopic);
    }

    public async Task UpdateAsync(TopicDto topic)
    {
        var updatedTopic = _mapper.Map<Topic>(topic);

        var nextVersion = await _versionRepository.GetByVersionAsync(++topic.Version);

        if (nextVersion is null)
        {
            nextVersion = new VersionEntity { Version = topic.Version };
            nextVersion.Id = await _versionRepository.AddAsync(nextVersion);
        }

        updatedTopic.Versions = new List<VersionEntity>() { nextVersion };

        await _topicRepository.UpdateAsync(updatedTopic);
    }

    public async Task DeleteAsync(int id)
    {
        await _topicRepository.DeleteAsync(id);
    }
}