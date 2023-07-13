using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Repositories;

public class LevelRepository : ILevelRepository
{
    private readonly GrammarPulseDbContext _dbContext;

    public LevelRepository(GrammarPulseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Level>> GetAllAsync()
    {
        return await _dbContext.Levels.ToListAsync();
    }

    public async Task<int> AddAsync(Level level)
    {
        _dbContext.Levels.Add(level);
        await _dbContext.SaveChangesAsync();
        return level.Id;
    }

    public async Task UpdateAsync(Level level)
    {
        _dbContext.Levels.Update(level);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _dbContext.Levels.Remove(new Level() { Id = id });
        await _dbContext.SaveChangesAsync();
    }
}