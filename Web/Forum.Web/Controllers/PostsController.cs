using Forum.Data.Common.Repositories;
using Forum.Data.Models;
using Forum.Services.Data;
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
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
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
            var postId = await this.postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);
            return this.RedirectToAction("ById", new { id = postId });
        }
    }
}
