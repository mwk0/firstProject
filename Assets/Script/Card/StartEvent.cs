using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Script.Entity;
using Script.Pub.Event;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using Script.Util;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Script.Card
{
    //进入战斗场景触发的事件
    public class StartEvent : MonoBehaviour
    {
        //事件系统
        public EventCenter EventCenter;
        public BattleConstParamSet BattleConstParamSet;
        
        
        private void Start()
        {
            EventCenter = EventCenter.GetInstance();
            BattleConstParamSet = BattleConstParamSet.GetInstance();
            //生成卡组
            /*deck乱序转队列，形成卡组，第一次洗牌*/
            List<CardInfo> deckCardInfoList = AllParamEntity.GetInstance().GETDeckCards();
            EventCenter.TriggerEvent(EventDefine.initDeck,deckCardInfoList);
            //生成战场单元格
            
            //抽初始卡牌
            EventCenter.TriggerEvent(EventDefine.drawCards,BattleConstParamSet._init_handCards_Num);
            
        }
        
        
        private void Update()
        {
           
        }



        
        

    }
}