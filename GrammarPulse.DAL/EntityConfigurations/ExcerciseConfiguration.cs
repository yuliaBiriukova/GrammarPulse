using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations;

public class ExcerciseConfiguration : IEntityTypeConfiguration<Excercise>
{
    public void Configure(EntityTypeBuilder<Excercise> builder)
    {
        builder.Property(e => e.Type).IsRequired();

        builder.Property(e => e.UkrainianValue).IsRequired().HasMaxLength(256);

        builder.Property(e => e.EnglishValue).IsRequired().HasMaxLength(256);
    }
}