using LLama;

namespace Chat.BLs.Services
{
    public interface IModelStorage
    {
        void Load();

        LLamaModel? Get(string modelName);
    }
}
