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
        private Vector3 deck_icon_position;//卡组的位置，抽卡从这里出现
        private GameObject handCardArea;//手牌区域
        private GameObject leftBoot;
        
        private void Start()
        {
            deck_icon_position = GameObject.Find("deck").transform.position;
            handCardArea = GameObject.Find("handCardArea");
            leftBoot = GameObject.Find("leftBoot");
            //初始化对象池
            BasePoolMap basePoolMap = BasePoolMap.GetInstance();
            _cardPool = basePoolMap.GetPoolByPrefabPath("prefabs/cardFrame", handCardArea.transform, 10, 30,true, null, null, null, null);
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
                Debug.Log(card.cardArt.name);
                //前端
                var cardFrame = _cardPool.Get();
                CardCreater create = cardFrame.GetComponent<CardCreater>();
                create.InitCardCreaterByCardinfo(card);
                //设置卡牌初始位置
                Debug.Log(deck_icon_position);
                cardFrame.transform.position = deck_icon_position;
                //目标位置
                RectTransform leftHandAreaRect = handCardArea.GetComponent<RectTransform>();
                Debug.Log(leftHandAreaRect.offsetMin.x);
                //Vector3 targetPosition = GetHandCardTargetPosition(leftHandAreaRect.offsetMin.x)
                //移动卡牌到手牌区
                LeanTween.moveLocalX(cardFrame, 50f * i, 2f).setEaseInOutQuint();
            }
            
        }

        //计算抽卡时 从卡组移动到手牌的位置，
        private Vector3 GetHandCardTargetPosition(float leftStartX,float handAreaWidth,int cardNum)
        {
            return Vector3.zero;
        }

    }
}