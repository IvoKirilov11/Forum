using System.Threading.Tasks;

namespace Forum.Services.Data
{
    public interface IVotesService
    {
        Task VoteAsync(int postId, string userId, bool isUpVote);
    }
}
