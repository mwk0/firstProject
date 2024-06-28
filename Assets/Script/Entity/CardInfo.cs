using System;
using Script.Card;
using Script.Prefabs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Entity
{
    //卡牌信息实体类
    public class CardInfo
    {
        public int id;
        //编号
        public string no;
        //名称
        public string cardName;
        public string cardArt; //图片名称
        public string cardText;
        public int cardCost;//消耗
        public int cardType;//卡牌类型：部队，建筑，策略,法术
        
    }
}