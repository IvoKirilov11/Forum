﻿using Forum.Data.Models;
using Forum.Services.Data;
using Forum.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {

        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VotesResponseModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(input.PostId,userId,input.IsUpVote);
            var votes = this.votesService.GetVotes(input.PostId);
            return new VotesResponseModel { VotesCount = votes };
        }
    }
}
