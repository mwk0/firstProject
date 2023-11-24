using System;
using System.Collections.Generic;
using System.Linq;
using Script.Entity;
using Script.Pub.Singletonbase;
using UnityEngine;
using Object = System.Object;
using Random = System.Random;

namespace Script.MainTest
{
    public class CardBattleStart : MonoBehaviour
    {
        private void Start()
        {
            //全局参数
            AllParamEntity allParams = AllParamEntity.GetInstance();
            //加载所有的卡牌图鉴
            CardInfo[] allCardScripteObjects = Resources.LoadAll("scripteObject/card", typeof(CardInfo)).Cast<CardInfo>().ToArray();
            AllParamEntity._allCardInfo = allCardScripteObjects;
            
            //开始游戏(测试：从所有牌里随机挑20张)
            int allCardCount = AllParamEntity._allCardInfo.Length;
            List<CardInfo> deck = allParams.GETDeckCards();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                deck.Add(AllParamEntity._allCardInfo[random.Next(allCardCount)]);
            }
            Debug.Log(allParams.GETDeckCards().Count);
            Debug.Log(allCardCount);
        }
    }
}