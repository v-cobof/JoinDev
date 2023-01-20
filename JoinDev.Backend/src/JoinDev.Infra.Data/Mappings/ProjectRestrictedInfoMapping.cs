using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoinDev.Infra.Data.Mappings
{
    public class ProjectRestrictedInfoMapping : IEntityTypeConfiguration<ProjectRestrictedInfo>
    {
        public void Configure(EntityTypeBuilder<ProjectRestrictedInfo> builder)
        {
            builder.HasKey(c => c.Id);

            // 1:1
            builder.HasOne(c => c.Project)
                .WithOne(c => c.ProjectRestrictedInfo)
                .HasForeignKey<ProjectRestrictedInfo>(c => c.ProjectId);

            builder.HasMany(c => c.Links)
                .WithOne()
                .HasForeignKey(t => t.AggregateId);

            builder.ToTable("ProjectsRestrictedInfo");
        }
    }
}
