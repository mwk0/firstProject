using System;
using System.Collections.Generic;
using Script.Pub.Singletonbase;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Script.Pub.Pool
{
    //缓存池基类，基础单例基类
    public class BasePool : SingletonBaseManager<BasePool>
    {
        public bool collectionChecks = true;
        //字典
        private Dictionary<String, ObjectPool<GameObject>> _pools;
        //预制体路径
        private String _prefabPath;
        //父物体
        private Transform _parents;
        //最小池
        private int _minPoolSize = 100;
        //最大池
        private int _maxPoolSize = 500;

        
        /**
         * 用预制体的资源路径获取对应的缓存池，并且可以自定义生命周期方法。
         */
        public ObjectPool<GameObject> GetObjectPoolByName(String prefabPath,Transform parent,int minPoolSize,int maxPoolSize
            ,Func<GameObject> createFunc,Action<GameObject> getAction,Action<GameObject> releaseAction,Action<GameObject> destroyAction)
        {
            _prefabPath = prefabPath;
            _parents = parent;
            if (!_pools.ContainsKey(prefabPath))
            {
                createFunc ??= OnCreatePoolItem;
                getAction ??= OnGetPoolItem;
                releaseAction ??= OnReleasePoolItem;
                destroyAction ??= OnDestroyPoolItem;
                _minPoolSize = minPoolSize>0?minPoolSize:_minPoolSize;
                _maxPoolSize = maxPoolSize>0?maxPoolSize:_maxPoolSize;
                if (_maxPoolSize < _minPoolSize)
                {
                    Debug.LogError("缓存池: （"+prefabPath+"）的大小设置错误！！！");
                }
                //添加某个类型的池
                _pools.Add(prefabPath,new ObjectPool<GameObject>(createFunc,getAction,releaseAction,destroyAction,collectionChecks,_minPoolSize,_maxPoolSize));
            }

            return _pools[prefabPath];
        }


        private void OnDestroyPoolItem(GameObject obj)
        {
            Object.Destroy(obj);
        }

        private void OnReleasePoolItem(GameObject obj)
        {
            obj.SetActive(false);
        }

        private void OnGetPoolItem(GameObject obj)
        {
            obj.SetActive(true);
        }

        //用预制体路径作为字典的key（路径不用包括Assets 和 Resources ）
        private GameObject OnCreatePoolItem()
        {
            return Object.Instantiate(Resources.Load<GameObject>(_prefabPath),_parents);
        }
 
    }
    
}