using GrammarPulse.BLL.Entities;
using GrammarPulse.BLL.Repositories;
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Repositories;

public class VersionRepository : IVersionRepository
{
    private readonly GrammarPulseDbContext _dbContext;

    public VersionRepository(GrammarPulseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VersionEntity?> GetByVersionAsync(int version)
    {
        return await _dbContext.Versions.FirstOrDefaultAsync(v => v.Version == version);
    }

    public async Task<int> AddAsync(VersionEntity version)
    {
        _dbContext.Versions.Add(version);
        await _dbContext.SaveChangesAsync();
        return version.Id;
    }
}