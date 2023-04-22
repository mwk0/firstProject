using System;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using Object = System.Object;

namespace Script.MainTest
{
    public class GemTest : MonoBehaviour
    {
        private float _timer;
        private ObjectPool<GameObject> _pool;
        private void Start()
        {
            String name = gameObject.name;
            Debug.Log(name);
            var substring = name.Substring(0, name.IndexOf("Clone", StringComparison.Ordinal)-1);
            Debug.Log(substring);
            _pool = SingletonBaseManager<BasePool>.GetInstance().GetObjectPoolByName(substring,transform,10,30,null,null,null,null);
        }

        private void OnEnable()
        {
            _timer = 0;
        }

        
        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > 2)
            {
                _pool.Release(gameObject);
            }
        }
    }
}