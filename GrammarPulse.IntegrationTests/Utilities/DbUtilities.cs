using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace GrammarPulse.IntegrationTests.Utilities;

public class DbUtilities
{
    public static GrammarPulseDbContext GetGrammarPulseDbContext(string dbName)
    {
        var dbContextOptions = GetDbOptions(dbName);
        return new GrammarPulseDbContext(dbContextOptions);
    }

    private static DbContextOptions<GrammarPulseDbContext> GetDbOptions(string dbName)
    {
        var builder = new DbContextOptionsBuilder<GrammarPulseDbContext>();

        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        builder.UseInMemoryDatabase(databaseName: dbName)
             //the in-memory DB doesn't support transactions, this line prevents throwing the error
             .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .UseInternalServiceProvider(serviceProvider);
        
        return builder.Options;
    }
}