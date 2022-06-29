using Forum.Data.Common.Repositories;
using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Data
{
    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetVotes(int postId)
        {
            var votes = this.votesRepository.All()
                .Where(x => x.PostId == postId).Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = votesRepository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }

            else
            {
                vote = new Vote
                {
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                    UserId = userId,
                    PostId = postId,
                };
                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
