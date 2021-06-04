using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulful_Speech_Web
{
    public class PersonalChatHub : Hub
    {
        public async Task Send(string userId, string message, string userName, string dateTime)
        {
            await Clients.User(userId).SendAsync("Send", message, userName, dateTime);
        }
    }
}
