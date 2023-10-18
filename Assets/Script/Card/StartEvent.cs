using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Script.Entity;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using Script.Util;
using UnityEngine;

namespace Script.Card
{
    //进入战斗场景触发的事件
    public class StartEvent : MonoBehaviour
    {
        private PrefabPool _cardPool;
        private List<CardInfo> _handCards = new List<CardInfo>();
        private Queue<CardInfo> _deck = new Queue<CardInfo>();
       
        private void Start()
        {
            //deck乱序转队列，形成卡组，第一次洗牌
            //卡组列表
            List<CardInfo> deckCards = AllParamEntity.GetInstance().GETDeckCards();
            ShuffleDeck(deckCards);
            //抽卡
            DrawInitCards();
            
        }

        //洗牌
        private void ShuffleDeck(List<CardInfo> cardList)
        {
           ListUtils.Shuffle(cardList);
           foreach (var card in cardList)
           {
               _deck.Enqueue(card);
           }
           
        }
        
        //初始抽卡 7张
        private void DrawInitCards()
        {
            BasePoolMap basePoolMap = BasePoolMap.GetInstance();
            _cardPool = basePoolMap.GetPoolByPrefabPath("card", transform, 10, 30,true, null, null, null, null);
            
        }

        //创建card物体到指定位置
        private void CreateCardInPosition()
        {
            
        }
       
    }
}