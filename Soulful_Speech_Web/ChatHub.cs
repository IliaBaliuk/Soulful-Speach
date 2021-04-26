using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulful_Speech_Web
{
    public class ChatHub : Hub
    {
        private static string currentRoom;

        public void Join(string chatRoom)
        {
            currentRoom = chatRoom;
            Groups.AddToGroupAsync(Context.ConnectionId, chatRoom);
        }
        public async Task Send(string message,string userName, string dateTime)
        {
            await Clients.Group(currentRoom).SendAsync("Send", message, userName, dateTime);
        }

        public void Disconnect()
        {
            if (currentRoom != null)
            {
                Groups.RemoveFromGroupAsync(Context.ConnectionId, currentRoom);
            }      
        }
    }
}
