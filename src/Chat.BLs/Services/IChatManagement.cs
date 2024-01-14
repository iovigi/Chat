namespace Chat.BLs.Services
{
    public interface IChatManagement
    {
        IChatSession? Get(Guid conversationId, string? prompt = null, string? model = null);
    }
}
