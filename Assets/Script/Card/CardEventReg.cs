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
            battleConstParamSet._cardFramePrefab_unit = (GameObject) Resources.Load("prefabs/cardFrame_unit");
            battleConstParamSet.handCardArea = GameObject.Find("handCardArea");
            battleConstParamSet.deckCardArea = GameObject.Find("deck");
            battleConstParamSet.graveArea = GameObject.Find("grave");
            battleConstParamSet.deck_icon_position = battleConstParamSet.deckCardArea.transform.position;
            battleConstParamSet.deckOutPosition = GameObject.Find("deckOut").transform.position;
            battleConstParamSet.graveOutPosition = GameObject.Find("graveOut").transform.position;
            battleConstParamSet.CardFrameWidth = battleConstParamSet._cardFramePrefab_unit.GetComponent<RectTransform>().rect.width;
            battleConstParamSet.HandAreaWidth = battleConstParamSet.handCardArea.GetComponent<RectTransform>().rect.width;
            battleConstParamSet.cell_build_Prefab = (GameObject)Resources.Load("prefabs/cell_build");
            battleConstParamSet.cell_unit_Prefab = (GameObject)Resources.Load("prefabs/cell_unit");
            battleConstParamSet.battleArea = GameObject.Find("battleArea");
            //给手牌区域组件设置参数
            HandCardArea handCardArea = HandCardArea.GetInstance();
            handCardArea.BattleConstParamSet = battleConstParamSet;
            //注册事件
            EventCenter = EventCenter.GetInstance();
            Action <List<CardInfo>> initDeck = handCardArea.InitDeck;
            EventCenter.AddListener(EventDefine.initDeck, initDeck);
            Action<int> drawCards = handCardArea.DrawCards;
            EventCenter.AddListener(EventDefine.drawCards,drawCards);
            Action InitBattleCell = handCardArea.InitBattleCell;
            EventCenter.AddListener(EventDefine.InitBattleCell,InitBattleCell);
        }
        
        private void Start()
        {
            
        }
        
        
    }
}