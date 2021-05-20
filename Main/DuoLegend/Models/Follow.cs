using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Follow
    {
        private string _followerId;
        private string _followingId;

        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
    }
}
