using GrammarPulse.BLL.Enums;

namespace GrammarPulse.BLL.Entities;

public class Excercise
{
    public int Id { get; set; }

    public ExcerciseType Type { get; set; }

    public string UkrainianValue { get; set; }

    public string EnglishValue { get; set; }

    public int TopicId { get; set; }

    public Topic Topic { get; set; }
}