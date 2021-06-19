using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string message, string sender, string reciever)
        {
            int boxChatId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever));

            if(boxChatId == 0)
            {
                DAO.ChatDAO.addBoxChat(Int32.Parse(sender), Int32.Parse(reciever));
                boxChatId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever)); //dong nay chua optimize
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, boxChatId.ToString());
            if (message != "")
            {
                DAO.ChatDAO.addChatContent(boxChatId, message, Int32.Parse(sender));
            }                   
            await Clients.Groups(boxChatId.ToString()).SendAsync("ReceiveMessage", message, sender);
        }
    }
}
