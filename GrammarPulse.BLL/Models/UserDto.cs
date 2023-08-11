using GrammarPulse.BLL.Enums;

namespace GrammarPulse.BLL.Models;

public record UserDto(
    string Email,
    UserRole Role)
{
    public int Id { get; set; }
};