using JoinDev.Application.Models;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Mappers
{
    public static class ProjectMapper
    {
        public static void HandleProjectTypeMapping(this ProjectModel incompleteModel, Project project)
        {
            if (project is StudyProject) 
                HandleStudyProject(incompleteModel, project as StudyProject);
            
            if(project is JobProject)
                HandleJobProject(incompleteModel, project as JobProject);     
        }

        private static void HandleStudyProject(ProjectModel incompleteModel, StudyProject project)
        {
            incompleteModel.ProjectType = ProjectType.Study;
            incompleteModel.StudyProjectLevel = project.StudyProjectLevel;
        }

        private static void HandleJobProject(ProjectModel incompleteModel, JobProject project)
        {
            incompleteModel.ProjectType = ProjectType.Job;
            incompleteModel.JobProjectLevel = project.JobProjectLevel;
            incompleteModel.MemberPayment = project.MemberPayment;
        }
    }
}
