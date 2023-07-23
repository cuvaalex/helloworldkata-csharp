using Microsoft.EntityFrameworkCore;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Persistence;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<HelloWorldRecord> HelloWorlds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HelloWorldRecordConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "HelloWorldDb");
    }
}

