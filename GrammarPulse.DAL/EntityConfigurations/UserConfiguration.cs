using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email).IsRequired().HasMaxLength(256);

            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Role).IsRequired();
        }
    }
}