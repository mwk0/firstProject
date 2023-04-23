using System;
using System.Collections.Generic;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.Pub.Pool
{
    //缓存池字典
    public class BasePoolMap : SingletonBaseManager<BasePoolMap>
    {
        private Dictionary<String, PrefabPool> _pools = new();

        public PrefabPool GetPoolByPrefabPath(string prefabPath,Transform parents,int minSize,int maxSize,bool collectionChecks,
            Func<GameObject> createFunc,Action<GameObject> getAction,Action<GameObject> releaseAction,Action<GameObject> destroyAction)
        {
            Debug.Log(prefabPath);
            if (!_pools.ContainsKey(prefabPath))
            {
                PrefabPool pool = new PrefabPool(prefabPath,parents,minSize,maxSize,collectionChecks,createFunc,getAction,releaseAction,destroyAction);
                _pools.Add(prefabPath,pool);
            }
            return _pools[prefabPath];
        }
    }
    
}