using System;
using Services.StorageService;

namespace Services.StatsService
{
    [Serializable]
    public class StatDto : IStorageItem
    {
        string IStorageItem.Id => StatId;
        public string StatId;
        public string StatType;

        public StatDto(StatModel initModel)
        {
            StatId = initModel.StatID;
            StatType = initModel.StatType;
        }
    }
}