using JoinDev.Domain.Entities;

namespace JoinDev.Domain.Data
{
    public interface ILinkSourceDAO
    {
        Task<bool> CreateLinkSource(LinkSource category);
    }
}
