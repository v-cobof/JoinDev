﻿using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data.Extensions
{
    public static class HierarchyConfig
    {
        public static ModelBuilder ConfigureTablePerTypeForProjectHierarchy(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyProject>().ToTable("StudyProjects");
            modelBuilder.Entity<JobProject>().ToTable("JobProjects");

            return modelBuilder;
        }
    }
}
