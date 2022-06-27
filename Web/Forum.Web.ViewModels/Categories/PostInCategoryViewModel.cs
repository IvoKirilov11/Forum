﻿using Forum.Data.Models;
using Forum.Services.Mapping;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Forum.Web.ViewModels.Categories
{
    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public DateTime CreateOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 300
                        ? content.Substring(0, 300) + "..."
                        : content;
            }
        }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}