namespace GrammarPulse.BLL.Entities;

public class VersionEntity
{
    public int Id { get; set; }

    public int Version { get; set; }

    public ICollection<Topic> Topics { get; set; }
}