namespace GrammarPulse.ViewModels;

public record TopicViewModel(
    int Id,
    string Name,
    string Content,
    int LevelId,
    string Version);