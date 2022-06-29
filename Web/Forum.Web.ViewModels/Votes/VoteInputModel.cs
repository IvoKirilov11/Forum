using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Web.ViewModels.Votes
{
    public class VoteInputModel
    {
        public int PostId { get; set; }

        public bool IsUpVote { get; set; }
    }
}
