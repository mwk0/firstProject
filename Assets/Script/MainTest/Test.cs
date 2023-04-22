using System;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using UnityEngine;
using UnityEngine.Pool;
using Object = System.Object;

namespace Script.MainTest
{
    public class Test : MonoBehaviour
    {
        private ObjectPool<GameObject> _gemPool;
        private ObjectPool<GameObject> _coinPool;
        private void Start()
        {
            //单例获取basePool
            BasePool basePool = SingletonBaseManager<BasePool>.GetInstance();
            _gemPool = basePool.GetObjectPoolByName("Gem", transform, 10, 30, null, null, null, null);
            _coinPool = basePool.GetObjectPoolByName("Coin", transform, 10, 30, null, null, null, null);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var obj = _gemPool.Get();
                obj.transform.localScale = new Vector3(100, 100, 100);
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标转换世界坐标
                Vector2 uiPos = transform.InverseTransformPoint(worldPos);
                obj.transform.position = uiPos;
            }

            if (Input.GetMouseButtonDown(1))
            {
                var obj = _coinPool.Get();
                obj.transform.localScale = new Vector3(100, 100, 100);
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标转换世界坐标
                Vector2 uiPos = transform.InverseTransformPoint(worldPos);
                obj.transform.position = uiPos;
            }
        }
    }
}