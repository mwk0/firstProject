using System;
using Script.Pub.Singletonbase;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Script.Pub.Pool
{
    //封装ObjectPool的类
    public class PrefabPool
    {
        private String _prefabPath;
        private Transform _parents;
        private ObjectPool<GameObject> _pool;
        private int _minSize;
        private int _maxSize;

        public PrefabPool(string prefabPath, Transform parents,int minSize,int maxSize,bool collectionChecks,
            Func<GameObject> createFunc,Action<GameObject> getAction,Action<GameObject> releaseAction,Action<GameObject> destroyAction)
        {
            _prefabPath = prefabPath;
            _parents = parents;
            createFunc ??= OnCreatePoolItem;
            getAction ??= OnGetPoolItem;
            releaseAction ??= OnReleasePoolItem;
            destroyAction ??= OnDestroyPoolItem;
            _minSize = minSize > 0 ? minSize : 100;
            _maxSize = maxSize > _minSize ? maxSize : 500;
            _pool = new ObjectPool<GameObject>(createFunc, getAction, releaseAction, destroyAction, collectionChecks,
                _minSize, _maxSize);
        }

        public GameObject Get()
        {
            return _pool.Get();
        }

        public void Release(GameObject obj)
        {
            _pool.Release(obj);
        }

        public void Clear()
        {
            _pool.Clear();
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
            GameObject o = GameObject.Instantiate(Resources.Load<GameObject>(_prefabPath),_parents);
            return o;
        }
    }
    
    
}