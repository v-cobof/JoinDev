using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class ThemeMapping : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasKey(c => c.Id);

            // N:N
            builder.HasMany(c => c.Projects)
                .WithMany(c => c.Themes);

            builder.ToTable("Themes");
        }
    }
}

