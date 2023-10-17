using System;
using Script.Entity;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.MainTest
{
    public class Temp : MonoBehaviour
    {
        private void Start()
        {
            AllParamEntity allParamEntity = SingletonBaseManager<AllParamEntity>.GetInstance();
            Debug.Log(allParamEntity.GETDeckCards().Count);
        }
    }
}