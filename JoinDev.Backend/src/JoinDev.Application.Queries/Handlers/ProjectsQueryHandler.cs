using JoinDev.Application.Data;
using JoinDev.Application.Models;
using JoinDev.Application.Queries.Extensions;
using JoinDev.Application.Queries.ViewModels;
using JoinDev.Domain.Core.Communication;
using JoinDev.Domain.Core.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Queries.Handlers
{
    public class ProjectsQueryHandler : BaseQueryHandler<ProjectsQuery, List<ProjectDisplayViewModel>>
    {
        private readonly IReadRepository<ProjectReadModel> _repository;

        public ProjectsQueryHandler(IBusHandler bus, IReadRepository<ProjectReadModel> repository) : base(bus)
        {
            _repository = repository;
        }

        public async override Task<QueryResult<List<ProjectDisplayViewModel>>> Handle(ProjectsQuery query, CancellationToken cancellationToken)
        {
            var conditionsAndFilters = new (bool, Func<ProjectReadModel, bool>)[]
            {
                (query.ProjectType.NotDefault(), model => model.ProjectType == query.ProjectType),
                (query.ThemesIds.NotDefault(), model => query.ThemesIds.All(queryId => model.Themes.Any(theme => theme.Id == queryId)))
            };

            var validFilters = GetValidFilters(conditionsAndFilters);
            var filter = BuildFilter(validFilters);

            var result = await _repository
                .Find(filter)
                .Sort(new BsonDocument("count", 1))
                .Limit(query.PageSize)
                .Skip(query.PageNumber * query.PageSize)
                .ToListAsync(cancellationToken);

            return result.Select(t => (ProjectDisplayViewModel) t).ToList();
        }
    }
} 
