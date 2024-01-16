using Chat.BLs.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Chat.BLs.Services
{
    internal class ChatManagement(IModelStorage modelStorage, IMemoryCache memoryCache, IOptions<ModelSettings> modelSettingOptions) : IChatManagement
    {
        public IChatSession? Get(Guid conversationId, string? prompt, string? model = null)
        {
            return memoryCache.GetOrCreate<IChatSession?>(conversationId, (cacheEntry) =>
            {
                var ex = modelStorage.Get(model ?? modelSettingOptions.Value.DefaultModel);

                if(ex == null)
                {
                    return null;
                }

                return new ChatSession(new LLama.ChatSession(ex));
            });
        }
    }
}
