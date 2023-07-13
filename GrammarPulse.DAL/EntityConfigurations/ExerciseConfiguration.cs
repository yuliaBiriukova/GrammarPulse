using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.Property(e => e.Type).IsRequired();

        builder.Property(e => e.UkrainianValue).IsRequired().HasMaxLength(256);

        builder.Property(e => e.EnglishValue).IsRequired().HasMaxLength(256);
    }
}