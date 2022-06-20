using Forum.Data.Common.Repositories;
using Forum.Data.Models;
using Forum.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IDeletableEntityRepository<Post> postsRepository,UserManager<ApplicationUser> userManager)
        {
            this.postsRepository = postsRepository;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var post = new Post
            {
                CategoryId = input.CategoryId,
                Content = input.Content,
                Title = input.Title,
                UserId = user.Id,
            };
            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return this.RedirectToAction("ById", new {id = post.Id});
        }
    }
}
