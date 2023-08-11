using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Repositories;

public class CompletedTopicRepository : ICompletedTopicRepository
{
    private readonly GrammarPulseDbContext _dbContext;

    public CompletedTopicRepository(GrammarPulseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(CompletedTopic completedTopic)
    {
        _dbContext.Add(completedTopic);
        await _dbContext.SaveChangesAsync();
        return completedTopic.Id;
    }

    public async Task<CompletedTopic?> GetAsync(int topicId, int userId)
    {
        return await _dbContext.CompletedTopics.FirstOrDefaultAsync(t => t.TopicId == topicId && t.UserId == userId);
    }

    public async Task UpdateAsync(CompletedTopic completedTopic)
    {
        _dbContext.Update(completedTopic);
        await _dbContext.SaveChangesAsync();
    }
}