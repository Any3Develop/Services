
namespace Services.SaveManagerService
{
    public interface ISaveManager
    {
        bool HasUser(string userId);
        void LoadUser(string userId);
        void SaveUser(string userId);
        void RemoveUser(string userId);
        
        bool HasSaves(string saveDataKey);
        void Load(string saveDataKey);
        void Save(string saveDataKey);
        void Remove(string saveDataKey);
    }
}