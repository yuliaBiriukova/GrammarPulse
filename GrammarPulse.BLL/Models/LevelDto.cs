namespace GrammarPulse.BLL.Models;

public record LevelDto(
    string Code,
    string Name)
{
    public int Id { get; set; }
};