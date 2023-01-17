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

            builder.Property(t => t.PublicDescription).HasColumnType("varchar(500)");

            // 1:N
            builder.HasOne(c => c.Creator)
                .WithMany(c => c.ProjectsAsCreator)
                .HasForeignKey(t => t.CreatorId);

            // N:N
            builder.HasMany(c => c.MemberUsers)
                .WithMany(c => c.ProjectsAsMember)
                .UsingEntity(t => t.ToTable("MembersInProjects"));

            // N:N
            builder.HasMany(c => c.InterestedUsers)
                .WithMany(c => c.ProjectsAsInterested)
                .UsingEntity(c => c.ToTable("InterestedInProjects"));

            builder.ToTable("Projects");
        }
    }
}
