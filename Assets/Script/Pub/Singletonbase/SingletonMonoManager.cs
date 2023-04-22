using UnityEngine;

//继承MonoBehaviour的单例基类
namespace Script.Pub.Singletonbase
{
    public class SingletonMonoManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T GetInstance()
        {
            if (instance == null)//
            {
                //创建空物体
                GameObject obj = new GameObject();
                obj.name = typeof(T).ToString();
                //切换场景不销毁obj
                DontDestroyOnLoad(obj);
                //把T脚本挂载到obj上，由unity来实例化。即使其他物体上也挂载了T脚本，有多个T实例，通过GetInstance方法获得的都是obj上的T实例
                instance = obj.AddComponent<T>();

            }
            return instance;
        }
    }
}
