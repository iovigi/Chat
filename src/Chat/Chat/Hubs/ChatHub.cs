using Chat.BLs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatManagement chatManagement;

        public ChatHub(IChatManagement chatManagement)
        {
            this.chatManagement = chatManagement;
        }

        public async Task SendMessage(Guid conversationId, string message)
        {
            var session = chatManagement.Get(conversationId);

            if(session == null)
            {
                return;
            }

            var response = string.Join(' ', session.Chat(message).ToList());

            await Clients.Caller.SendAsync("ReceiveMessage", response);
        }
    }
}
