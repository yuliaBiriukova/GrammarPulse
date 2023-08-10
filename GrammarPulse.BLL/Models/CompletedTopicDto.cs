namespace GrammarPulse.BLL.Models;

public record CompletedTopicDto (
    int TopicId,
    int Percentage)
{
    public int Id { get; set; }
    public int UserId { get; set; }
}