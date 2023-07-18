using GrammarPulse.BLL.Enums;

namespace GrammarPulse.ViewModels;

public record ExerciseViewModel(
    int Id,
    ExerciseType Type,
    string UkrainianValue,
    string EnglishValue,
    int TopicId);