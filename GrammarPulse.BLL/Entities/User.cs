using GrammarPulse.BLL.Enums;

namespace GrammarPulse.BLL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }
    }
}