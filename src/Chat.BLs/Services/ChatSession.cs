using LLama;
using LLama.Common;

namespace Chat.BLs.Services
{
    internal class ChatSession(LLama.ChatSession chatModel) : IChatSession
    {
        public IAsyncEnumerable<string> Chat(string text)
            => chatModel.ChatAsync(new ChatHistory.Message(AuthorRole.User, text));
    }
}
