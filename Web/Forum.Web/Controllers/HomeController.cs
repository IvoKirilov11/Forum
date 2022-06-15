namespace Forum.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Forum.Data;
    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;
    using Forum.Web.ViewModels;
    using Forum.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Forum.Services.Mapping;
    using Forum.Services.Data;

    public class HomeController : BaseController
    {
        
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>();
            viewModel.Categories = categories;
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
