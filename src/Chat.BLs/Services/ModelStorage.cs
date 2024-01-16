using Chat.BLs.Configurations;
using LLama;
using LLama.Common;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chat.BLs.Services
{
    internal class ModelStorage(IOptions<ModelSettings> modelSettingOptions) : IModelStorage
    {
        private readonly ModelSettings modelSettings = modelSettingOptions.Value;
        private readonly ConcurrentDictionary<string, LLama.InteractiveExecutor> models = new();

        public LLama.InteractiveExecutor? Get(string modelName)
        {
            return models
                .TryGetValue(modelName, out var model) ? 
                    model : default;
        }

        public void Load()
        {
            foreach(var modelSettings in modelSettings.Models)
            {
                var parameters = new ModelParams(modelSettings.Path)
                {
                    ContextSize = 512,
                };

                var weights = LLamaWeights.LoadFromFile(parameters);

                var context = new LLamaContext(weights, parameters);

                var ex = new InteractiveExecutor(context);

                models.TryAdd(modelSettings.Name, ex);
            }
        }
    }
}
