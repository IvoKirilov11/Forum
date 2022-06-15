using Forum.Data.Models;
using Forum.Services.Mapping;
using System;

namespace Forum.Web.ViewModels.Categories
{
    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public DateTime CreateOn { get; set; }
        public string Title { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}