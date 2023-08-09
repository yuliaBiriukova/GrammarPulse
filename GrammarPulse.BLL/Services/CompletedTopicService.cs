using AutoMapper;
using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Repositories;

namespace GrammarPulse.BLL.Services;

public class CompletedTopicService : ICompletedTopicService
{
    private readonly IMapper _mapper;
    private readonly ICompletedTopicRepository _completedTopicRepository;

    public CompletedTopicService(IMapper mapper, ICompletedTopicRepository completedTopicRepository)
    {
        _mapper = mapper;
        _completedTopicRepository = completedTopicRepository;
    }

    public async Task<int> AddAsync(CompletedTopicDto completedTopic)
    {
        var newCompletedTopic = _mapper.Map<CompletedTopic>(completedTopic);
        return await _completedTopicRepository.AddAsync(newCompletedTopic);
    }

    public async Task<CompletedTopicDto?> GetAsync(int topicId, int userId)
    {
        var completedTopic = await _completedTopicRepository.GetAsync(topicId, userId);
        return _mapper.Map<CompletedTopicDto>(completedTopic);
    }

    public async Task UpdateAsync(CompletedTopicDto completedTopic)
    {
        var updatedCompletedTopic = _mapper.Map<CompletedTopic>(completedTopic);
        await _completedTopicRepository.UpdateAsync(updatedCompletedTopic);
    }
}