namespace Chat.BLs.Services
{
    public interface IModelStorage
    {
        void Load();

        LLama.InteractiveExecutor? Get(string modelName);
    }
}
