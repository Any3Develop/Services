using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Services.PoolService
{
    public abstract class BasePool : IPool
    {
        private DiContainer _diContainer;
        private Dictionary<Type, List<IPoolable>> _storagePoolable;

        [Inject]
        private void Inject(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _storagePoolable = new Dictionary<Type, List<IPoolable>>();
        }

        public object Get(Type concreteType, params object[] args)
        {
            if (concreteType == null)
            {
                throw new ArgumentException("ConcreteType is missing");
            }

            if (concreteType.GetInterfaces().All(x => x != typeof(IPoolable)))
            {
                throw new ArgumentException("ConcreteType must implement IPoolable interface");
            }
            
            if (!_storagePoolable.ContainsKey(concreteType))
            {
                _storagePoolable.Add(concreteType, new List<IPoolable>());
            }

            var poolables = _storagePoolable[concreteType];
            if (poolables.Count == 0)
            {
                return Create(concreteType, args);
            }

            var poolable = poolables[0];
            poolables.RemoveAt(0);
            _diContainer.Inject(args);
            poolable.Parent(this);
            return poolable;
        }

        public T Get<T>(params object[] args ) where T : IPoolable
        {
            return (T)Get(typeof(T), args);
        }

        public void Return(IPoolable polable)
        {
            if (polable == null)
            {
                return;
            }
            
            var type = polable.GetType();
            if (!_storagePoolable.ContainsKey(type))
            {
                _storagePoolable.Add(type, new List<IPoolable>());
            }

            if (_storagePoolable[type].Contains(polable))
            {
                polable.Reset();
                return;
            }
            polable.Reset();
            _storagePoolable[type].Add(polable);
        }
        
        public object Create(Type concreteType, params object[] args)
        {
            return _diContainer.Instantiate(concreteType, args.Append(this));
        }
    }
}