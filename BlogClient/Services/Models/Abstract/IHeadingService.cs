using BlogClient.Contracts;
using BlogClient.Contracts.Heading;

namespace BlogClient.Services.Models.Abstract
{
    public interface IHeadingService
    {
        Task<BaseContract<ListHeading.ListHeadingRoot>> GetHeadingList(int page, int size);
        Task<BaseContract<Heading>> GetHeadingById(int id);
        Task<BaseContract<Heading>> AddHeading(CreateHeading createHeading);
        Task<BaseContract<Heading>> UpdateHeading(UpdateHeading updateHeading);
        Task<BaseContract<Heading>> DeleteHeading(int id);
    }
}
