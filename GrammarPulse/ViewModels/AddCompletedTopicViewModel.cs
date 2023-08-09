namespace GrammarPulse.ViewModels;

public record AddCompletedTopicViewModel(
    int TopicId,
    int UserId,
    int Percentage);