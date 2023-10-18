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
        

        private PrefabPool _cardPool;//card对象池
        private List<CardInfo> _handCards = new List<CardInfo>();//手牌
        private Queue<CardInfo> _deck = new Queue<CardInfo>();//卡组
        private int _init_handCards_Num = 7;
        private Vector3 deck_icon_position = GameObject.Find("deck").transform.localPosition;//卡组的位置，抽卡从这里出现
        
        private void Start()
        {
            //初始化对象池
            BasePoolMap basePoolMap = BasePoolMap.GetInstance();
            _cardPool = basePoolMap.GetPoolByPrefabPath("card", transform, 10, 30,true, null, null, null, null);
            /*deck乱序转队列，形成卡组，第一次洗牌*/
            //卡组列表
            List<CardInfo> deckCards = AllParamEntity.GetInstance().GETDeckCards();
            ShuffleDeck(deckCards);
            //获取手牌数据
            DrawInitCards();
            
        }
        
        
        private void Update()
        {
           
        }
        
        

        //洗牌
        private void ShuffleDeck(List<CardInfo> cardList)
        {
           ListUtil.Shuffle(cardList);
           foreach (var card in cardList)
           {
               _deck.Enqueue(card);
           }
           
        }
        
        //初始抽卡 
        private void DrawInitCards()
        {
            //后端
            for (int i = 0; i < _init_handCards_Num; i++)
            {
                CardInfo card = _deck.Dequeue();
                _handCards.Add(card);
            }
            //前端
            var gameObjectCard = _cardPool.Get();
            //设置卡牌初始位置
            gameObjectCard.transform.localPosition = deck_icon_position;
            //移动卡牌到手牌区
            gameObjectCard.GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }

    }
}