using BlogClient.Contracts;
using BlogClient.Contracts.Writer;

namespace BlogClient.Services.Models.Abstract
{
    public interface IWriterService
    {
        Task<BaseContract<ListWriterResponse>> GetWriterList(int page, int size);
        Task<BaseContract<Writer>> GetWriterById(int id);
        Task<BaseContract<Writer>> DeleteWriter(int id);
        Task<BaseContract<Writer>> AddWriter(CreateWriter createWriter);
        Task<BaseContract<Writer>> UpdateWriter(UpdateWriter updateWriter);
        Task<BaseContract<GetHeadingsByWriterId>> GetHeadingsByWriterId(int writerId);
    }
}
