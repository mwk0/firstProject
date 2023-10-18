using System;
using System.Collections.Generic;
using Script.Entity;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.MainTest
{
    public class CardBattleStart : MonoBehaviour
    {
        private void Start()
        {
            //开始游戏
            AllParamEntity allParams = AllParamEntity.GetInstance();
            List<CardInfo> deck = allParams.GETDeckCards();
            for (int i = 0; i < 20; i++)
            {
                deck.Add(new CardInfo("00"+i,"这是编号00"+i+"的卡"));
            }
            Debug.Log(allParams.GETDeckCards().Count);
        }
    }
}