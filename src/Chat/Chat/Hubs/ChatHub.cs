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

        public async Task SendMessage(Guid conversationId, string message, int index)
        {
            var session = chatManagement.Get(conversationId);

            if(session == null)
            {
                return;
            }

            await foreach (var text in session.Chat(message))
            {
                await Clients.Caller.SendAsync("ReceiveMessage", text, index);
            }
        }
    }
}
