using System;
using System.Collections.Generic;
using System.Linq;
using Script.Entity;
using Script.Pub.Singletonbase;
using Script.Util;
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
            UnitCardRecord unitCardRecord = JsonUtil.GETObjectFromJsonFile<UnitCardRecord>("cardinfounit.json");
            List<CardInfoUnit> cardInfoUnits = unitCardRecord.Records;
            foreach (var cardInfoUnit in cardInfoUnits)
            {
                AllParamEntity._allCardInfo.Add(cardInfoUnit);
            }
            
            //开始游戏(测试：从所有牌里随机挑20张)
            int allCardCount = AllParamEntity._allCardInfo.Count;
            List<CardInfo> deck = allParams.GETDeckCards();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                deck.Add(AllParamEntity._allCardInfo[random.Next(allCardCount)]);
            }
            
            //读取城市关卡配置
            string cityName = "city_1.json";
            int passIndex = 0;
            CityConfig cityConfig = JsonUtil.GETObjectFromJsonFile<CityConfig>(cityName);
            PassConfig passConfig = cityConfig.passConfigs[passIndex];
            
        }
    }
}