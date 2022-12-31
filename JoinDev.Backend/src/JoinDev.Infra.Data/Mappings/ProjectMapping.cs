using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(c => c.Id);

            // 1:N
            builder.HasOne(c => c.Creator)
                .WithMany(c => c.ProjectsAsCreator);

            // N:N
            builder.HasMany(c => c.MemberUsers)
                .WithMany(c => c.ProjectsAsMember);

            // N:N
            builder.HasMany(c => c.InterestedUsers)
                .WithMany(c => c.ProjectsAsInterested);

            // N:N
            builder.HasMany(c => c.Themes)
                .WithMany(c => c.Projects);

            // 1:1
            builder.HasOne(c => c.ProjectRestrictedInfo)
                .WithOne(c => c.Project)
                .HasForeignKey<ProjectRestrictedInfo>(c => c.ProjectId);

            builder.ToTable("Projects");
        }
    }
}
