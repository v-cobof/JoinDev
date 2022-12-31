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

            // 1:N
            builder.HasMany(c => c.ProjectsAsCreator)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            // N:N
            builder.HasMany(c => c.ProjectsAsMember)
                .WithMany(c => c.MemberUsers);

            // N:N
            builder.HasMany(c => c.ProjectsAsInterested)
                .WithMany(c => c.InterestedUsers);

            // 1:N
            builder.HasMany(c => c.Links)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);


            builder.ToTable("Users");
        }
    }
}
