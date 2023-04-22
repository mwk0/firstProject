using System;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using UnityEngine;
using UnityEngine.Pool;

namespace Script.MainTest
{
    public class Test : MonoBehaviour
    {
        private ObjectPool<GameObject> _pool;
        private void Start()
        {
            //单例获取basePool
            BasePool basePool = SingletonBaseManager<BasePool>.GetInstance();
            _pool = basePool.GetObjectPoolByName("Gem", transform, 10, 30, null, null, null, null);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var obj = _pool.Get();
                obj.transform.position = Input.mousePosition;
            }
        }
    }
}