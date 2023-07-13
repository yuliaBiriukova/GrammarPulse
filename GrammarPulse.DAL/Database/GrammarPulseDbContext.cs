using GrammarPulse.BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrammarPulse.DAL.Database;

public class GrammarPulseDbContext : DbContext
{
    public DbSet<Level> Levels { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<VersionEntity> Versions { get; set; }

    public DbSet<Exercise> Exercises { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<CompletedTopic> CompletedTopics { get; set; }

    public GrammarPulseDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Topic>()
            .HasOne(t => t.Level)
            .WithMany(l => l.Topics)
            .HasForeignKey(t => t.LevelId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.Topic)
            .WithMany(t => t.Exercises)
            .HasForeignKey(e => e.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Topic>()
            .HasMany(t => t.Versions)
            .WithMany(v => v.Topics)
            .UsingEntity(t => t.ToTable("TopicVersions"));

        modelBuilder.Entity<CompletedTopic>()
            .HasOne(c => c.Topic)
            .WithMany()
            .HasForeignKey(c => c.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CompletedTopic>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Level>().HasData(
            new { Id = 1, Code = "A1", Name = "Beginner" },
            new { Id = 2, Code = "A2", Name = "Pre-Intermediate" },
            new { Id = 3, Code = "B1", Name = "Intermediate" },
            new { Id = 4, Code = "B2", Name = "Upper-Intermediate" },
            new { Id = 5, Code = "C1", Name = "Advanced" },
            new { Id = 6, Code = "C2", Name = "Proficient" });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrammarPulseDbContext).Assembly);
    }
}