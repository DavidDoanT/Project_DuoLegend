using DuoLegend.DAO;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Hubs
{
    public class LikeHub : Hub
    {
        public void AddLike(string likerId, string userId)
        {
            int a=Int32.Parse(likerId);
            int b = Int32.Parse(userId);
            if (ProfileDAO.addLike(a, b))
            {

            }
            else
            {
                ProfileDAO.deleteLike(a, b);
            }
        }
    }
}
