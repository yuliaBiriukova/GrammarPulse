using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations;

public class CompletedTopicConfiguration : IEntityTypeConfiguration<CompletedTopic>
{
    public void Configure(EntityTypeBuilder<CompletedTopic> builder)
    {
        builder.Property(e => e.Percentage).IsRequired();
    }
}