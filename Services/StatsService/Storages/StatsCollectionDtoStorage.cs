using Services.SaveManagerService;
using Services.StorageService;

namespace Services.StatsService
{
    public class StatsCollectionDtoStorage : Storage<StatsCollectionDto>
    {
        public StatsCollectionDtoStorage(ISavableStorage savableStorage)
        {
            savableStorage.Register(this);
        }
    }
}