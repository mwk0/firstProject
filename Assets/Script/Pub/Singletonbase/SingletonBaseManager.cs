namespace Script.Pub.Singletonbase
{
    //单例基类
    public class SingletonBaseManager<T> where T : new()
    {
        private static T _instance;

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }
}