using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(128);

        builder.Property(e => e.Content).IsRequired();
    }
}