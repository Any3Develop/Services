using Services.StorageService;

namespace Services.InteractorSystem
{
    public interface IInteractorService : IStorageItem
    {
        void Init();
        void Dispose();
    }
}