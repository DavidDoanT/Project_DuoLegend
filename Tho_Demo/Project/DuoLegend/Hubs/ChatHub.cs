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
            //--------

            //--------
            int boxChatId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever));

            if (boxChatId == 0)
            {
                DAO.ChatDAO.addBoxChat(Int32.Parse(sender), Int32.Parse(reciever));
                boxChatId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever)); //dong nay chua optimize
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, boxChatId.ToString());
            if (message != "")
            {
                DAO.ChatDAO.addChatContent(boxChatId, message, Int32.Parse(sender));
                //List<BoxChatDetail> test = DAO.ChatDAO.GetListBoxChatDetailById(boxChatId);
                await Clients.Groups(boxChatId.ToString()).SendAsync("ReceiveMessage", message, sender);
            }

        }

        public async Task InitMessage(string sender, string reciever)
        {
            int boxChatId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever));
            if(boxChatId != 0)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, boxChatId.ToString());
                DAO.ChatDAO.changeSeenState(Int32.Parse(sender), boxChatId);
                List<BoxChatDetail> chatList = DAO.ChatDAO.GetListBoxChatDetailById(boxChatId);
                foreach (var chat in chatList)
                {
                    await Clients.Caller.SendAsync("ReceiveMessage", chat.Content, chat.SendFrom.ToString());
                }              
            }     
        }

        public async Task Notification(string sender)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, sender+"notifi");
        }
    }
}
