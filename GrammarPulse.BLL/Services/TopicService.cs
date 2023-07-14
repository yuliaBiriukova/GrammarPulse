using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;

namespace GrammarPulse.BLL.Services;

public class TopicService : ITopicService
{
    private readonly IMapper _mapper;
    private readonly ITopicRepository _topicRepository;

    public TopicService(IMapper mapper, ITopicRepository topicRepository)
    {
        _mapper = mapper;
        _topicRepository = topicRepository;
    }

    public async Task<IEnumerable<TopicDto>> GetByLevelIdAsync(int levelId)
    {
        var topics = await _topicRepository.GetByLevelIdAsync(levelId);
        return _mapper.Map<IEnumerable<TopicDto>>(topics);
    }

    public async Task<int> AddAsync(TopicDto topic)
    {
        var newTopic = _mapper.Map<Topic>(topic);
        return await _topicRepository.AddAsync(newTopic);
    }

    public async Task UpdateAsync(TopicDto topic)
    {
        var updatedTopic = _mapper.Map<Topic>(topic);
        await _topicRepository.UpdateAsync(updatedTopic);
    }

    public async Task DeleteAsync(int id)
    {
        await _topicRepository.DeleteAsync(id);
    }
}