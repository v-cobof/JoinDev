using JoinDev.Domain.Data;
using JoinDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JoinDev.Infra.Data.DAO
{
    public class LinkSourceDAO : ILinkSourceDAO
    {
        private readonly JoinDevContext _context;

        public LinkSourceDAO(JoinDevContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLinkSource(LinkSource category)
        {
            _context.LinkSources.Add(category);

            return await _context.Commit();
        }

        public async Task<LinkSource> GetLinkSourceByName(string name)
        {
            return await _context.LinkSources.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}
