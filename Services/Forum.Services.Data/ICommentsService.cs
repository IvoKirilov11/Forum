﻿using System.Threading.Tasks;

namespace Forum.Services.Data
{
    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int postId);
    }
}
