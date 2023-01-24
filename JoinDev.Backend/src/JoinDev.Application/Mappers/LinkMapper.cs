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

        public static void SetAsUserLinks(this IEnumerable<LinkModel> links)
        {
            foreach (var link in links)
            {
                link.SetAsUserLink();
            }
        }
    }
}
