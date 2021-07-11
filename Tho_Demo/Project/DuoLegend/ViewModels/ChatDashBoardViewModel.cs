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

        private int _userSelfAvatarId;
        private int _userOtherAvatarId;
        private int _userOtherId;
        private int _userSelfId;

        public int UserSelfId
        {
            get { return _userSelfId; }
            set { _userSelfId = value; }
        }


        public int UserOtherId
        {
            get { return _userOtherId; }
            set { _userOtherId = value; }
        }


        public int UserOtherAvatarId
        {
            set { _userOtherAvatarId = value; }
        }


        public int UserSelfAvatarId
        {
            set { _userSelfAvatarId = value; }
        }
        public string UserOtherAvatarPath
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/11.12.1/img/profileicon/" + _userOtherAvatarId.ToString() + ".png";
            }
        }
        public string UserSelfAvatarPath
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/11.12.1/img/profileicon/" + _userSelfAvatarId.ToString() + ".png";
            }
        }
    }
}
