using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Entities;
using JoinDev.Domain.ValueObjects;
using JoinDev.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data
{
    public sealed class JoinDevContext : DbContext
    {
        public JoinDevContext(DbContextOptions<JoinDevContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<JobProject> JobProjects { get; set; }
        public DbSet<StudyProject> StudyProjects { get; set; }

        public DbSet<ProjectRestrictedInfo> ProjectsRestrictedInfo { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeCategory> ThemeCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Link> Links { get; set; }
        public DbSet<LinkSource> LinkSources { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(JoinDevContext).Assembly)
                .ConfigureTablePerTypeForProjectHierarchy();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<IEnumerable<Event>>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
