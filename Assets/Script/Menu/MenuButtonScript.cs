using System;
using System.Collections.Generic;
using System.Threading;
using Script.Entity;
using Script.Pub.Singletonbase;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Menu
{
    public class MenuButtonScript:MonoBehaviour
    {
        public void StartGame()
        {
            //创建一个空物体挂载单例EmptyObjectForParamEntity对象，用来在场景间传递参数
            /*EmptyObjectForParamEntity paramEntity = SingletonMonoManager<EmptyObjectForParamEntity>.GetInstance();
            Dictionary<String, String> param = paramEntity._param;
            param.Add("menu","start");
            
            Thread.Sleep(2000);*/
            SceneManager.LoadScene("TestScene");
        }
    }
}