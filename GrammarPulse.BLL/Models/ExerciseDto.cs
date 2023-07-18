using GrammarPulse.BLL.Enums;

namespace GrammarPulse.BLL.Models;

public record ExerciseDto (
    ExerciseType Type,
    string UkrainianValue,
    string EnglishValue,
    int TopicId)
{
    public int Id { get; set; }
};