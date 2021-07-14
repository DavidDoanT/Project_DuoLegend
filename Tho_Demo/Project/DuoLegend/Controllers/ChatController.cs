using DuoLegend.DAO;
using DuoLegend.Models;
using DuoLegend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatDashBoard(int otherId)
        {
            int id = HttpContext.Session.GetInt32("id") ?? default; //get current user's id
            if (id == default)
            {
                return RedirectToAction("RedirectLoginPage", "Account");
            }
            List<int> listUserHaveChat = ChatDAO.getListUserHaveChat(id);
            if(listUserHaveChat.Count() == 0)
            {
                return View(new ChatDashBoardViewModel());
            }
            Dictionary<int, BoxChatDetail> listLastMessageForSort = new Dictionary<int, BoxChatDetail>();
            foreach (var item in listUserHaveChat)
            {
                BoxChatDetail LastMessage = ChatDAO.GetLastMessageDetail(ChatDAO.getBoxChatId(id, item));
                listLastMessageForSort.Add(item, LastMessage);
            }

            var listLastMessageTemp = from message in listLastMessageForSort
                                      orderby message.Value.TimeSend descending
                                      select message;

            Dictionary<int, BoxChatDetail> listLastMessageSorted = listLastMessageTemp.ToDictionary(pair => pair.Key, pair => pair.Value);
            ChatDashBoardViewModel model = new ChatDashBoardViewModel();
            model.ListMessageAndUserHaveChatWith = listLastMessageSorted;

            if (otherId == 0)
            {
                otherId = listLastMessageSorted.First().Key;
            }

            string[] UserSelfInfor = UserDAO.getInGameNameServerById(id);
            string[] UserOtherInfor = UserDAO.getInGameNameServerById(otherId);
            if (UserSelfInfor is null || UserOtherInfor is null)
            {
                return RedirectToAction("error","Home");
            }
            model.UserSelfAvatarId = RiotAPI.RiotAPI.GetAccountIdInfor(UserSelfInfor[0], UserSelfInfor[1]).ProfileIconId;
            model.UserOtherAvatarId = RiotAPI.RiotAPI.GetAccountIdInfor(UserOtherInfor[0], UserOtherInfor[1]).ProfileIconId;

            model.UserOtherId = otherId;
            model.UserSelfId = id;
            return View(model);
        }
    }
}
