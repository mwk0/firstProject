using System;
using System.Collections.Generic;
using Script.Entity;
using Script.Pub.Event;
using Script.Util;
using UnityEngine;

namespace Script.Card
{
    public class CardEventReg : MonoBehaviour
    {
        //事件系统
        public EventCenter EventCenter;
        
        private void Awake()
        {
            //battle界面的参数管理类
            BattleConstParamSet battleConstParamSet = BattleConstParamSet.GetInstance();
            //初始化battle参数
            battleConstParamSet._cardFramePrefab = (GameObject) Resources.Load("prefabs/cardFrame");
            battleConstParamSet.handCardArea = GameObject.Find("handCardArea");
            battleConstParamSet.deckCardArea = GameObject.Find("deck");
            battleConstParamSet.graveArea = GameObject.Find("grave");
            battleConstParamSet.deck_icon_position = battleConstParamSet.deckCardArea.transform.position;
            battleConstParamSet.deckOutPosition = GameObject.Find("deckOut").transform.position;
            battleConstParamSet.graveOutPosition = GameObject.Find("graveOut").transform.position;
            battleConstParamSet.CardFrameWidth = battleConstParamSet._cardFramePrefab.GetComponent<RectTransform>().rect.width;
            battleConstParamSet.HandAreaWidth = battleConstParamSet.handCardArea.GetComponent<RectTransform>().rect.width;
            //给手牌区域组件设置参数
            HandCardArea handCardArea = HandCardArea.GetInstance();
            handCardArea.BattleConstParamSet = battleConstParamSet;
            //注册事件
            EventCenter = EventCenter.GetInstance();
            Action <List<CardInfo>> initDeck = handCardArea.InitDeck;
            EventCenter.AddListener(EventDefine.initDeck, initDeck);
            Action<int> drawCards = handCardArea.DrawCards;
            EventCenter.AddListener(EventDefine.drawCards,drawCards);
        }
        
        private void Start()
        {
            
        }
        
        
    }
}