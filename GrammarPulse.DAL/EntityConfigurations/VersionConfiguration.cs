using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrammarPulse.BLL.EntityConfigurations;

internal class VersionConfiguration : IEntityTypeConfiguration<VersionEntity>
{
    public void Configure(EntityTypeBuilder<VersionEntity> builder)
    {
        builder.Property(e => e.Version).IsRequired();
    }
}