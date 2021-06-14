using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.Models;
using Microsoft.AspNetCore.SignalR;


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

            DAO.ChatDAO.addChatContent(boxChatId,message,Int32.Parse(sender));

            boxChatDetail chatDetail = DAO.ChatDAO.GetBoxChatDetailById(boxChatId);
            
            

            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
