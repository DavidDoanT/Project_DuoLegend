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
        public IActionResult ChatDashBoard()
        {
            int id = HttpContext.Session.GetInt32("id") ?? default; //get current user's id
            if (id == default)
            {
                return RedirectToAction("RedirectLoginPage", "Account");
            }
            List<int> listUserHaveChat = ChatDAO.getListUserHaveChat(id);
            Dictionary<int, BoxChatDetail> listLastMessageForSort = new Dictionary<int, BoxChatDetail>();
            foreach (var item in listUserHaveChat)
            {
                BoxChatDetail LastMessage = ChatDAO.GetLastMessageDetail(ChatDAO.getBoxChatId(id, item));
                listLastMessageForSort.Add(item, LastMessage);
            }

            var listLastMessageTemp = from message in listLastMessageForSort
                                        orderby message.Value.TimeSend
                                        select message;

            Dictionary<int, BoxChatDetail> listLastMessageSorted = listLastMessageTemp.ToDictionary(pair => pair.Key, pair => pair.Value);
            ChatDashBoardViewModel model = new ChatDashBoardViewModel();
            model.ListMessageAndUserHaveChatWith = listLastMessageSorted;
           return View(model);
        }
    }
}
