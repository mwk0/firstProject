
using Script.Entity;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using UnityEngine;


namespace Script.MainTest
{
    public class Test : MonoBehaviour
    {
        private PrefabPool _gemPool;
        private PrefabPool _coinPool;
        private void Start()
        {
            //单例获取basePool
            BasePoolMap basePoolMap = SingletonBaseManager<BasePoolMap>.GetInstance();
            _gemPool = basePoolMap.GetPoolByPrefabPath("Gem", transform, 10, 30,true, null, null, null, null);
            _coinPool = basePoolMap.GetPoolByPrefabPath("Coin", transform, 10, 30, true, null,null, null, null);
            //测试从menu场景传递来的参数
            EmptyObjectForParamEntity paramEntity = SingletonMonoManager<EmptyObjectForParamEntity>.GetInstance();
            Debug.Log(paramEntity._param["menu"]);
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