using LLama;

namespace Chat.BLs.Services
{
    internal class ChatSession(IChatModel chatModel) : IChatSession
    {
        public IEnumerable<string> Chat(string text)
            => chatModel.Chat(text);
    }
}
