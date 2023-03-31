using JoinDev.Application.Models;
using JoinDev.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Mappers
{
    public static class LinkMapper
    {
        public static IEnumerable<LinkModel> ToLinkModels(this IEnumerable<Link> links)
        {
            foreach(var link in links)
            {
                yield return link;
            }
        }

        public static IEnumerable<Link> ToLinkEntities(this IEnumerable<LinkModel> links)
        {
            return links.Select(t => new Link(t.Name, t.Url, t.LinkSourceId));
        }
    }
}
