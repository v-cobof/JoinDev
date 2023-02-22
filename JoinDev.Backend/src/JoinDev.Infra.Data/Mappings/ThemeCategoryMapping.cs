using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class ThemeCategoryMapping : IEntityTypeConfiguration<ThemeCategory>
    {
        public void Configure(EntityTypeBuilder<ThemeCategory> builder)
        {
            builder.HasKey(c => c.Id);

            // 1:N
            builder.HasMany(c => c.Themes)
                .WithOne(c => c.ThemeCategory)
                .HasForeignKey(c => c.ThemeCategoryId);

            builder.ToTable("ThemeCategory");
        }
    }
}
