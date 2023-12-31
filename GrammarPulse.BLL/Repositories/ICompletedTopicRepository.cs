﻿using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface ICompletedTopicRepository
{
    Task<int> AddAsync(CompletedTopic completedTopic);

    Task<CompletedTopic?> GetAsync(int topicId, int userId);

    Task<IEnumerable<CompletedTopic>> GetByLevelAsync(int levelId, int userId);

    Task UpdateAsync(CompletedTopic completedTopic);
}