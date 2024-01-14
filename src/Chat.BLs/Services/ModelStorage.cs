using Chat.BLs.Configurations;
using LLama;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace Chat.BLs.Services
{
    internal class ModelStorage(IOptions<ModelSettings> modelSettingOptions) : IModelStorage
    {
        private readonly ModelSettings modelSettings = modelSettingOptions.Value;
        private readonly ConcurrentDictionary<string, LLamaModel> models = new();

        public LLamaModel? Get(string modelName)
        {
            return models
                .TryGetValue(modelName, out var model) ? 
                    model : default;
        }

        public void Load()
        {
            foreach(var modelSettings in modelSettings.Models)
            {
                var model = new LLamaModel(new LLamaParams(
                    model: Path.Combine(modelSettings.Path),
                    n_ctx: 512,
                    interactive: true,
                    repeat_penalty: 1.0f,
                    verbose_prompt: false));

                models.TryAdd(modelSettings.Name, model);
            }
        }
    }
}
