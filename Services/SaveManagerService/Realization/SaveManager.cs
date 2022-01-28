using System;
using System.Linq;
using UnityEngine;

namespace Services.SaveManagerService
{
    public class SaveManager : ISaveManager
    {
        private readonly ISerializeHelper _serializeHelper;
        private readonly ISavableStorage _savableStorage;
        private const string _usersPath = "users/";
        private const string _dataPath = "saveData/";
        public SaveManager(ISerializeHelper serializeHelper,
                           ISavableStorage savableStorage)
        {
            _serializeHelper = serializeHelper;
            _savableStorage = savableStorage;
        }

        public bool HasUser(string userId)
        {
            return _serializeHelper.HasSerializedData(_usersPath + userId);
        }

        public void LoadUser(string userId)
        {
            Load(_usersPath + userId);
        }

        public void SaveUser(string userId)
        {
            Save(_usersPath + userId);
        }
        public void RemoveUser(string userId)
        {
            Remove(_usersPath + userId);
        }

        public bool HasSaves(string saveDataKey)
        {
            return !string.IsNullOrEmpty(_dataPath + saveDataKey) && _serializeHelper.HasSerializedData(_dataPath +saveDataKey);
        }

        public void Save(string saveDataKey)
        {
            if (string.IsNullOrEmpty(saveDataKey))
            {
                Debug.LogError($"{this} : The key must not be Null or Empty");
                return;
            }

            var data = JsonHelper.ToJson(_savableStorage
                                             .GetAll()
                                             .Select(x => new SaveData {Key = x.GetTypeKey(), Data = x.Save()})
                                             .ToArray());
            _serializeHelper.SaveSerializedData(data, _dataPath + saveDataKey);
        }

        public void Remove(string saveDataKey)
        {
            if(!HasSaves(_dataPath + saveDataKey)) return;
            _serializeHelper.DeleteSerializedData(_dataPath + saveDataKey);
        }

        public void Load(string saveDataKey)
        {
            if (!HasSaves(_dataPath + saveDataKey))
            {
                Debug.LogError($"{this} : No save data exists for the key : {saveDataKey}");
                return;
            }

            var loadedData = _serializeHelper.GetSerializedData(_dataPath + saveDataKey);
            var saveDatas = JsonHelper.FromJson<SaveData>(loadedData).ToDictionary(x => x.Key);

            foreach (var savable in _savableStorage.GetAll())
            {
                var typeKey = savable.GetTypeKey();
                if (!saveDatas.ContainsKey(typeKey))
                {
                    Debug.LogError($"{this} : FarmData does not exist Savable : {typeKey}");
                    continue;
                }

                savable.Load(saveDatas[typeKey].Data);
            }
        }
    }

    [Serializable]
    public struct SaveData
    {
        public string Key;
        public string Data;
    }
}