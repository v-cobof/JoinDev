using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data.Extensions
{
    public static class LinkHierarchyConfig
    {
        public static ModelBuilder ConfigureTablePerTypeForLinkHierarchy(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectLink>().ToTable("ProjectLinks");
            modelBuilder.Entity<UserLink>().ToTable("UserLinks");

            return modelBuilder;
        }
    }
}
