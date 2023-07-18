using GrammarPulse.BLL.Entities;

namespace GrammarPulse.BLL.Repositories;

public interface IVersionRepository
{
    Task<VersionEntity?> GetByVersionAsync(int version);

    Task<int> AddAsync(VersionEntity version);
}