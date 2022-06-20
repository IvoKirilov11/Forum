using Forum.Data.Common.Repositories;
using Forum.Data.Models;
using System;
using System.Threading.Tasks;

namespace Forum.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                CategoryId = categoryId,
                Content = content,
                Title = title,
                UserId = userId,
            };
            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
            return post.Id;
        }
    }
}
