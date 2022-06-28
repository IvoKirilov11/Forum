using Forum.Data.Models;
using Forum.Services.Mapping;
using System;

namespace Forum.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>
    {

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}
