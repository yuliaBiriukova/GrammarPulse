namespace GrammarPulse.ViewModels;

public record CompletedTopicViewModel(
    int Id,
    int TopicId,
    int UserId,
    int Percentage);