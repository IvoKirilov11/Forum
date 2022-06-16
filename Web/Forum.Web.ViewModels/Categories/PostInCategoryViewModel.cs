using Forum.Data.Models;
using Forum.Services.Mapping;
using System;

namespace Forum.Web.ViewModels.Categories
{
    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public DateTime CreateOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent =>
            this.Content?.Length > 50 ? this.Content?.Substring(0,50) + "..." : this.Content;

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}