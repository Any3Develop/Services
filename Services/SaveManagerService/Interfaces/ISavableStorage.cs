using System.Collections.Generic;

namespace Services.SaveManagerService
{
    public interface ISavableStorage
    {
        void Register(ISavable savable);
        IEnumerable<ISavable> GetAll();
        T Get<T>() where T : ISavable;
    }
}