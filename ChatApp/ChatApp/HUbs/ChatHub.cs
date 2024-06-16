using ChatApp.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.HUbs
{
    public class ChatHub (IChat chat)    : Hub
    {

        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        private readonly IChat _chat = chat;

        public async Task SendMessage(Message message , Users user , Rooms rooms)
        {
            await Clients.Group(rooms.Name).SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinRoom(string room)
        {
            
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }


















    }
        //public async Task SendMessage(string user, string message, string room)
        //{
        //    await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
        //}

        //public async Task JoinRoom(string room)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, room);
        //}

        //public async Task LeaveRoom(string room)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        //}

}
