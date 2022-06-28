using Forum.Data.Models;
using Forum.Services.Mapping;
using Ganss.XSS;
using System;

namespace Forum.Web.ViewModels.Posts
{
    public class PostViewModel : IMapFrom<Post>
    {

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
