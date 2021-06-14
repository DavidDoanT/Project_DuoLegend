using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace DuoLegend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string sender, string reciever)
        {
            int chatBoxId = DAO.ChatDAO.getBoxChatId(Int32.Parse(sender), Int32.Parse(reciever));


            int a = 3;
            int cc = 4;
            
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
