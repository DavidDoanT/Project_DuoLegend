using DuoLegend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class ChatDashBoardViewModel
    {
        public Dictionary<int, BoxChatDetail> ListMessageAndUserHaveChatWith { get; set; }

        private int _userUsingAvatarId;
        private int _userChatWithAvatarId;
        private int _userChatWithId;

        public int UserChatWithId
        {
            get { return _userChatWithId; }
            set { _userChatWithId = value; }
        }


        public int UserChatWithAvatarId
        {
            set { _userChatWithAvatarId = value; }
        }


        public int UserUsingAvatarId
        {
            set { _userUsingAvatarId = value; }
        }
        public string UserChatWithAvatarPath
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/11.12.1/img/profileicon/" + _userChatWithAvatarId.ToString() + ".png";
            }
        }
        public string UserUsingAvatarPath
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/11.12.1/img/profileicon/" + _userUsingAvatarId.ToString() + ".png";
            }
        }
    }
}
