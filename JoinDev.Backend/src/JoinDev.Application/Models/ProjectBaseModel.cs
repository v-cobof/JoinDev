using JoinDev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Models
{
    public abstract class ProjectBaseModel : BaseModel
    {
        public string Title { get; set; }
        public string PublicDescription { get; set; }
        public int TotalSpots { get; set; }
        public int AvailableSpots { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public ProjectType ProjectType { get; set; }
        public List<ThemeModel> Themes { get; set; }

        public StudyProjectLevel? StudyProjectLevel { get; set; }
        public JobProjectLevel? JobProjectLevel { get; set; }
        public decimal? MemberPayment { get; set; }
    }
}
