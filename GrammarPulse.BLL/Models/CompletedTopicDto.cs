namespace GrammarPulse.BLL.Models;

public record CompletedTopicDto (
    int TopicId,
    int UserId, 
    int Percentage)
{
    public int Id { get; set; }
}