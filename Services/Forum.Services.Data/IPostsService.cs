using System.Threading.Tasks;

namespace Forum.Services.Data
{
    public interface IPostsService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId);
    }
}
