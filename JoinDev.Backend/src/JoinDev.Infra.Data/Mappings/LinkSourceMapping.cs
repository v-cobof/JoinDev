using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    internal class LinkSourceMapping : IEntityTypeConfiguration<LinkSource>
    {
        public void Configure(EntityTypeBuilder<LinkSource> builder)
        {
            builder.HasKey(c => c.Id);

            // 1:N
            builder.HasMany(c => c.Links)
                .WithOne(c => c.LinkSource)
                .HasForeignKey(c => c.LinkSourceId);

            builder.HasIndex(c => c.Name).IsUnique();

            builder.ToTable("LinkSource");
        }
    }
}
