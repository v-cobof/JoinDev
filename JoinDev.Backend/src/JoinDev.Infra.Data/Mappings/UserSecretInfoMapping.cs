using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class UserSecretInfoMapping : IEntityTypeConfiguration<UserSecretInfo>
    {
        public void Configure(EntityTypeBuilder<UserSecretInfo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User)
                .WithOne(c => c.UserSecretInfo)
                .HasForeignKey<UserSecretInfo>(c => c.UserId);

            builder.ToTable("UsersSecretInfo");
        }
    }
}
