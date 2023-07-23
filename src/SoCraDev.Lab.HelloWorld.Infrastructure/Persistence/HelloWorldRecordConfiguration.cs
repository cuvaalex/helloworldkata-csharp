using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoCraDev.Lab.HelloWorld.Infrastructure.Persistence;

internal class HelloWorldRecordConfiguration : IEntityTypeConfiguration<HelloWorldRecord>
{
    public void Configure(EntityTypeBuilder<HelloWorldRecord> builder)
    {
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(e => e.Name)
            .IsRequired();
    }
}