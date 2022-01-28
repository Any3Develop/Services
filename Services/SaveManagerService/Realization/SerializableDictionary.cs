using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Facebook.Unity;
using UnityEngine;

namespace Services.SaveManagerService
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> _keys;
        [SerializeField] private List<TValue> _values;
        public void Add(IDictionary<TKey, TValue> other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }
            this.AddAllKVPFrom(other);
        }
        
        [OnSerializing] // if non Unity serializer
        public void OnBeforeSerialize()
        {
            _keys = new List<TKey>(Keys);
            _values = new List<TValue>(Values);
        }

        [OnDeserialized] // if non Unity serializer
        public void OnAfterDeserialize()
        {
            Clear();
            for (var i = 0; i < _keys.Count; i++)
            {
                var key = _keys[i];
                var value = _values[i];
                Add(key, value);
            }
            _keys?.Clear();
            _values?.Clear();
        }

        public new void Clear()
        {
            _keys?.Clear();
            _values?.Clear();
            base.Clear();
        }
    }
}