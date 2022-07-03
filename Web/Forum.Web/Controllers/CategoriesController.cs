﻿using Forum.Services.Data;
using Forum.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Forum.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;
        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;
        private readonly IHttpContextAccessor http;

        public CategoriesController(ICategoriesService categoriesService, IPostsService postsService,
            IHttpContextAccessor http)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
            this.http = http;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.ForumPosts = this.postsService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);
            var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if(viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }
    }
}
