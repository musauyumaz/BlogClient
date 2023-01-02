using BlogClient.Contracts.Writer;

namespace BlogClient.Services.Models.Abstract
{
    public interface IWriterService
    {
        Task<ListWriterResponse> GetWriterList(int page, int size);
        Task<WriterResponse> GetWriterById(int id);
        Task<WriterResponse> DeleteWriter(int id);
        Task<WriterResponse> AddWriter(CreateWriter createWriter);
        Task<WriterResponse> UpdateWriter(UpdateWriter updateWriter);
        Task<GetHeadingsByWriterId> GetHeadingsByWriterId(int writerId);
    }
}
