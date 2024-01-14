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
                var llamaModel = modelStorage.Get(model ?? modelSettingOptions.Value.DefaultModel);

                if(llamaModel == null)
                {
                    return null;
                }

                if (prompt != null)
                {
                    llamaModel = llamaModel.WithPrompt(prompt);
                }

                return new ChatSession(llamaModel);
            });
        }
    }
}
