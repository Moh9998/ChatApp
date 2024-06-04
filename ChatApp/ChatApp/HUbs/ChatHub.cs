using Microsoft.AspNetCore.SignalR;

namespace ChatApp.HUbs
{
    public class ChatHub    : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        // Adding Rooms
    }
}
