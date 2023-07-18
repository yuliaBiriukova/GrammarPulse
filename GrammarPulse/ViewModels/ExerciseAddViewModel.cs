using GrammarPulse.BLL.Enums;

namespace GrammarPulse.ViewModels;

public record ExerciseAddViewModel(
    ExerciseType Type,
    string UkrainianValue,
    string EnglishValue,
    int TopicId);