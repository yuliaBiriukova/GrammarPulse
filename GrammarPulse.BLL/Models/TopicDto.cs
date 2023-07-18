namespace GrammarPulse.BLL.Models;

public record TopicDto(
    string Name,
    string Content,
    int LevelId)
{
    public int Id { get; set; }
    public int Version { get; set; }
}