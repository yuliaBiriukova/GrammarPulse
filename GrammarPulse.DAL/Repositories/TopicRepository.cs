using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Repositories;

public class TopicRepository : ITopicRepository
{
    private readonly GrammarPulseDbContext _dbContext;

    public TopicRepository(GrammarPulseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Topic>> GetByLevelIdAsync(int levelId)
    {
        return await _dbContext.Topics.Include(t => t.Versions).Where(t => t.LevelId == levelId).ToListAsync();
    }

    public async Task<Topic> GetByIdAsync(int id)
    {
        return await _dbContext.Topics.Include(t => t.Versions).SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<int> AddAsync(Topic topic)
    {
        _dbContext.Add(topic);
        await _dbContext.SaveChangesAsync();
        return topic.Id;
    }

    public async Task UpdateAsync(Topic topic)
    {
        _dbContext.Update(topic);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var topicToDelete = await _dbContext.Topics.FindAsync(id);

        if(topicToDelete is not null) 
        {
            _dbContext.Remove(topicToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}