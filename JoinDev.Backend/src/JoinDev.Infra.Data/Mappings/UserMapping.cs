using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(150)");
            builder.Property(c => c.Description).HasColumnType("varchar(500)");

            // 1:N
            builder.HasMany(c => c.Links)
                .WithOne()
                .HasForeignKey(c => c.AggregateId);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.ToTable("Users");
        }
    }
}
