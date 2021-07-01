﻿using System;
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
        /// <summary>
        /// receive message from client, add to database, and send message to receiver
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <returns></returns>
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
                string[] inforSender = DAO.UserDAO.getInGameNameServerById(Int32.Parse(sender));
                await Clients.Groups(reciever + "notifi").SendAsync("ReceiveNotification", inforSender[0],inforSender[1]);
            }

        }
        /// <summary>
        /// send a list of recent message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add connection
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task Notification(string sender)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, sender+"notifi");
        }
    }
}
